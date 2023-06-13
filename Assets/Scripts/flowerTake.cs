using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class flowerTake : MonoBehaviour
{

    public GameObject flower;
    public GameObject flowerController;
    public float awarenessIncrement = 0.2f;

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

        if (ineerTimer >= timeOfFirstAnimation)
        {
            ineerTimerRunning = false;
            ineerTimer = 0;
            flowerController.GetComponent<FlowerCounter>().player.GetComponent<Animator>().SetBool("PickingFromGround", false);
            flower.SetActive(false);
            gameObject.GetComponent<SphereCollider>().enabled = false;
            flowerController.GetComponent<FlowerCounter>().UpdateFlowersCount();
            flowerController.GetComponent<FlowerCounter>().player.transform.GetComponent<PlayerInput>().enabled = true;

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        ineerTimerRunning = true;
        flowerController.GetComponent<FlowerCounter>().player.transform.GetComponent<PlayerInput>().enabled = false;
        flowerController.GetComponent<FlowerCounter>().player.GetComponent<Animator>().SetBool("PickingFromGround", true);
        var awarenesComponent = flowerController.GetComponent<FlowerCounter>().realityAwereness.GetComponent<RealityAwareness>();
        awarenesComponent.awareness = Mathf.Clamp(awarenesComponent.awareness + awarenessIncrement, 0, 1);
        gameObject.GetComponent<AudioSource>().Play();

    }
}
