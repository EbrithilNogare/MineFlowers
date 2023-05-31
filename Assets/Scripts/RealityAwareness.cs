using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityAwareness : MonoBehaviour
{
    private AudioSource audioSource;

    [Range(0.0f, 1.0f)]
    public float awareness = .5f;
    
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

    void AlterAwareness(float diff)
    {
        awareness = Mathf.Clamp(awareness + diff, 0f, 1f);
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
