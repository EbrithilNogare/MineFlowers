using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject warpTarget;

    private void OnTriggerEnter(Collider other)
    {
        CharacterController cc = thePlayer.GetComponent<CharacterController>();

        cc.enabled = false;
        thePlayer.transform.position = warpTarget.transform.position + new Vector3(0,2,0);
        cc.enabled = true;
    }
}
