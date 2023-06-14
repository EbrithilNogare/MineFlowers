using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BrotherNPCController : MonoBehaviour
{

    public GameObject FlowersController;
    public AudioClip GoodEndingAudio;
    public AudioClip BadEndingAudio;

    public int CountTreshold;


    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<SphereCollider>().enabled = false;
        int count = 0;
        int.TryParse(FlowersController.GetComponent<FlowerCounter>().flowerCanvasText.GetComponent<TMP_Text>().text, out count);

        if (count >= CountTreshold)
            gameObject.GetComponent<AudioSource>().clip = GoodEndingAudio;
        else
            gameObject.GetComponent<AudioSource>().clip = BadEndingAudio;

        gameObject.GetComponent<AudioSource>().Play();
    }
}
