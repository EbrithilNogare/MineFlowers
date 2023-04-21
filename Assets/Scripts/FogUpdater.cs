using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FogUpdater : MonoBehaviour
{   
    public Material material;

    // Update is called once per frame
    void Update()
    {
        material.SetVector("_FogCenter", (Vector4)transform.position);
    }
}
