using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[ExecuteInEditMode]
public class BlitEditModeControler : MonoBehaviour
{
    public ScriptableRendererFeature scriptableRendererFeature;
    public bool shouldTurnOn = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isPlaying)
            scriptableRendererFeature.SetActive(shouldTurnOn);
        else
            scriptableRendererFeature.SetActive(false);
    }
}
