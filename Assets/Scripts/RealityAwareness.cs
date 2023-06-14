using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityAwareness : MonoBehaviour
{
    private AudioSource audioSource;

    public GameObject backgroundAudioObject;
    private AudioSource backgroundAudio;

    [Range(0.0f, 1.0f)]
    public float _awareness;
    public float awareness
    {
        get => _awareness;
        set
        {
            _awareness = Mathf.Clamp(value, 0f, 1f);
            backgroundAudio.volume = Mathf.Lerp(0.001f, 0.08f, _awareness);
        }
    }

    
    public float minDistance = 10f;
    public float maxDistance = 20f;
    public float width = 1f;
    public Material[] materials;

    public float minGlidDistance = 20f;
    public float maxGlidDistance = 30f;
    public Material postProecssmaterial;

    public AudioClip goodAudioClip;
    public AudioClip badAudioClip;

    // 0 = not playing
    // 1 = good effect playing
    // 2 = bad effect playing
    private int playing = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        backgroundAudio = backgroundAudioObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var material in materials)
        {
            material.SetFloat("_Min_Distance", Mathf.Lerp(minDistance, maxDistance - width, awareness));
            material.SetFloat("_Max_Distance", Mathf.Lerp(minDistance + width, maxDistance, awareness));
        }

        postProecssmaterial.SetFloat("_Distance", Mathf.Lerp(minGlidDistance, maxGlidDistance, awareness));
    }

    public void SetAudioRequest(bool goodEffect)
    {
        if((playing == 0 || playing == 2) && goodEffect)
        {
            audioSource.clip = goodAudioClip;
            audioSource.Play();
        }
        else if ((playing == 0 || playing == 1) && !goodEffect)
        {
            audioSource.clip = badAudioClip;
            audioSource.Play();
        }
    }

    public void UnSetAudioRequest()
    {
        audioSource.Stop();
    }

}
