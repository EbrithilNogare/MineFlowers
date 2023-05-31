using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerTake : MonoBehaviour
{

    public GameObject flower;
    public GameObject player;

    private float ineerTimer = 0;
    private bool ineerTimerRunning = false;
    private float timeOfFirstAnimation = .8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ineerTimerRunning)
        {
            ineerTimer += Time.deltaTime;
        }

        if(ineerTimer >= timeOfFirstAnimation)
        {
            ineerTimerRunning = false;
            ineerTimer = 0;
            player.GetComponent<Animator>().SetBool("PickingFromGround", false);
            flower.SetActive(false);
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ineerTimerRunning = true;
        player.GetComponent<Animator>().SetBool("PickingFromGround", true);
    }
}
