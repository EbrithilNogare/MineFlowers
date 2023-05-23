using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnterHandsController : MonoBehaviour
{
    public GameObject handsControllerUI;
    public GameObject Player;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("handsController triggered");
        handsControllerUI.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("handsController exited");
        handsControllerUI.SetActive(false);
    }
}
