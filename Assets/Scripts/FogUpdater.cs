using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogUpdater : MonoBehaviour
{   
public Material material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        material.SetVector("_FogCenter", (Vector4)transform.position);
    }
}
