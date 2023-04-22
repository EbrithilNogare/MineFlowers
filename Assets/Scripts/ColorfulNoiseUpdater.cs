using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[ExecuteInEditMode]
public class ColorfulNoiseUpdater : MonoBehaviour
{   
    public Material material;
    public ScriptableRendererFeature scriptableRendererFeature;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isPlaying)
            scriptableRendererFeature.SetActive(true);
        else
            scriptableRendererFeature.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        material.SetVector("_NoiseCenter", (Vector4)transform.position);
    }
}