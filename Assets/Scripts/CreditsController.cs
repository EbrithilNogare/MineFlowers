using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{

    public GameObject text;
    public GameObject image;
    public Material material;
    public float duration;
    public float delay;

    private bool animating = false;
    private float progress = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (animating)
        {
            if (delay > 0)
            {
                delay -= Time.deltaTime;
            }
            else { 
                progress += Time.deltaTime;
                material.SetFloat("_Progress", 1-(progress / duration));

                if (progress >= duration) {
                    animating = false;
                    text.SetActive(true);
                    material.SetFloat("_Progress", -1);
                }
            }
        }
    }

    public void ShowCredits()
    {
        image.SetActive(true);
        material.SetFloat("_Progress", 2);
        animating = true;
    }
}
