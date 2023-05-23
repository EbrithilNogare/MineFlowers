using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class EnterHandsController : MonoBehaviour
{
    GameObject handsController;
    public HandsControllerPrefab handsControllerPrefab;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("handsController triggered");
        handsControllerPrefab.EnableControls();
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("handsController exited");
        handsControllerPrefab.DisableControls();
    }
}
