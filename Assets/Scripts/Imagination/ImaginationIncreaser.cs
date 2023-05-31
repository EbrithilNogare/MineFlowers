using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class ImaginationIncreaser : MonoBehaviour
{
    public GameObject imaginationLevel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        imaginationLevel.GetComponent<RealityAwareness>().SetAudioRequest(true);
    }

    private void OnTriggerStay(Collider other)
    {
        imaginationLevel.GetComponent<RealityAwareness>().awareness = math.clamp(imaginationLevel.GetComponent<RealityAwareness>().awareness + 0.005f, 0, 1);

    }

    private void OnTriggerExit(Collider other)
    {
        imaginationLevel.GetComponent<RealityAwareness>().UnSetAudioRequest();
    }
}
