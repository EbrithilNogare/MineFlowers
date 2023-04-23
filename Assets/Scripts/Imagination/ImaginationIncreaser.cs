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

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("imagination increase");
        //if (imaginationLevel.GetComponent<RealityAwareness>().awareness > imaginationLevel.GetComponent<RealityAwareness>().minGlidDistance)
        imaginationLevel.GetComponent<RealityAwareness>().awareness = math.clamp(imaginationLevel.GetComponent<RealityAwareness>().awareness + 0.005f, 0, 1);

    }
}
