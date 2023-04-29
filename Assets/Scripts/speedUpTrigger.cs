using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedUpTrigger : MonoBehaviour
{
    public float newSpeed = 10f;

    public GameObject playerArmature;
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
        playerArmature.GetComponent<ThirdPersonController>().SprintSpeed = newSpeed;
    }
}
