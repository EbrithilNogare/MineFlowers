using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ImaginationUnlocker : MonoBehaviour
{
    [Header("--- Outer refs ---")]
    
    #region public GameObject imaginationLevel

    public GameObject imaginationLevel;

    #endregion

    [Header("--- Inner refs ---")]

    #region public float imaginationUnlockedAt

    [Range(0, 1f)]
    public float imaginationUnlockedAt;

    #endregion

    #region public GameObject lockedVariant

    public GameObject lockedVariant;

    #endregion

    #region public GameObject unlockedVariant

    public GameObject unlockedVariant;

    #endregion

    #region public float timeToChange

    public float timeToChange;

    #endregion

    #region public Material[] materialsToChange

    public Material[] materialsToChange;

    #endregion


    private RealityAwareness imagination;
    private float timeProgress = 0;
    private bool isChanging = false;

    private void Start()
    {
        imagination = imaginationLevel.GetComponent<RealityAwareness>();

        for (int i = 0; i < materialsToChange.Length; i++)
        {
            Material oldMaterial = materialsToChange[i];
            materialsToChange[i] = new Material(oldMaterial);
            materialsToChange[i].name += " copy";

            TraverseAndChangeMaterial(transform, oldMaterial, materialsToChange[i]);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (imagination.awareness >= imaginationUnlockedAt && !isChanging)
        {
            changingStart();
        }

        if (isChanging)
        {
            changingStep();
        }
    }

    private void changingStart()
    {
        isChanging = true;
        unlockedVariant.SetActive(true);
    }

    private void changingStep()
    {
        timeProgress += Time.deltaTime / timeToChange;
        
        foreach (var material in materialsToChange)
        {
            material.SetFloat("_Progress", timeProgress);
        }

        if (timeProgress >= 1) { 
            changingEnd();
        }
    }

    private void changingEnd()
    {
        isChanging = false;
        lockedVariant.SetActive(false);
    }

    void TraverseAndChangeMaterial(Transform parent, Material oldMaterial, Material newMaterial)
    {
        MeshRenderer renderer = parent.GetComponent<MeshRenderer>();

        if (
            renderer != null
            && (
                renderer.sharedMaterial.name == oldMaterial.name + " (Instance)"
                || renderer.sharedMaterial.name == oldMaterial.name
            )
            && renderer.sharedMaterial.shader.name == oldMaterial.shader.name
            )
        {
            renderer.sharedMaterial = newMaterial;
            
        }

        foreach (Transform child in parent)
        {
            TraverseAndChangeMaterial(child, oldMaterial, newMaterial);
        }
    }

}
