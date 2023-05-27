using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateNPC : MonoBehaviour
{
    private AudioSource audioSource;
    private bool firstTime = true;
    public bool isTalking;

    public bool repeat;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (audioSource.isPlaying)
        {
            isTalking = true; 
        }

        else
        {
            isTalking = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(repeat || firstTime)
            {
                firstTime = false;
                audioSource.Play();
            }
        }
    }
    
}
