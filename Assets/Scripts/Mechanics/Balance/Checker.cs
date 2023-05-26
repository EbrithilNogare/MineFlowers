using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Checker : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    public GameObject Canvas;

    public int COUNT;

    //Mathf.Abs(Left.transform.localEulerAngles.z + 180) < 0.01

    private bool playerNearbyLeft = false;
    private bool playerNearbyRight = false;

    private bool leftDone = false;
    private bool rightDone = false;

    private int winCount = 0;
    private int oneRoundCount = 0;

    private const int numOfRounds = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerNearbyLeft = true;
        playerNearbyRight = true;
        if (oneRoundCount >= 2)
            winCount++;
        if (winCount == numOfRounds)
            Canvas.SetActive(false);
        oneRoundCount = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        leftDone = false;
        rightDone = false;
        COUNT = winCount;
    }

    public void checkLU(InputAction.CallbackContext context)
    {
        //Debug.Log("check");
        if (playerNearbyLeft && Left.transform.localEulerAngles.z == 180)
        {
            Debug.Log("YES_LEFT");
            playerNearbyLeft = false;
            leftDone = true;
            oneRoundCount++;
        }

    }
    public void checkRU(InputAction.CallbackContext context)
    {
        //Debug.Log("check");
        if (playerNearbyRight && Right.transform.eulerAngles.z == 180)
        {
            Debug.Log("YES_RIGHT");
            oneRoundCount++;
            playerNearbyRight = false;
            leftDone = true;

        }

    }
    public void checkLD(InputAction.CallbackContext context)
    {
        //Debug.Log("check");
        if (playerNearbyLeft && Left.transform.eulerAngles.z == 0)
        {
            Debug.Log("YES_LEFT");
            oneRoundCount++;
            playerNearbyLeft = false;

        }
    }

    public void checkRD(InputAction.CallbackContext context)
    {
        //Debug.Log("check");
        if (playerNearbyRight && Right.transform.eulerAngles.z == 0)
        {
            Debug.Log("YES_RIGHT");
            oneRoundCount++;
            playerNearbyRight = false;
            rightDone = true;


        }
    }

}
