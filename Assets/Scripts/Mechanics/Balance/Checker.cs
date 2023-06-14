using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Checker : MonoBehaviour
{
    public GameObject Left;
    public GameObject Right;
    public GameObject Canvas;

    #region [SerializeField] public GameObject StartGamePosition { get; }

    [SerializeField]
    [Tooltip("TODO")]
    private GameObject _StartGamePosition;

    /// <summary>
    /// TODO
    /// </summary>
    public GameObject StartGamePosition => _StartGamePosition;

    #endregion


    #region [SerializeField] public GameObject Player { get; }

    [SerializeField]
    [Tooltip("TODO")]
    private GameObject _Player;

    /// <summary>
    /// TODO
    /// </summary>
    public GameObject Player => _Player;

    #endregion


    public int COUNT;

    //Mathf.Abs(Left.transform.localEulerAngles.z + 180) < 0.01

    private bool playerNearbyLeft = false;
    private bool playerNearbyRight = false;

    private bool leftDone = false;
    private bool rightDone = false;

    private int winCount = 5;
    private int oneRoundCount = 0;

    private const int numOfRounds = 5;
    MovePlayer move;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        move = _StartGamePosition.GetComponent<MovePlayer>();
        playerNearbyLeft = true;
        playerNearbyRight = true;
        if (oneRoundCount >= 2)
        {
            winCount++;
            move.currentSegment++;
            move.state = MovePlayer.State.moving;
        }
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
        if (playerNearbyLeft && Left.transform.localEulerAngles.z == 180)
        {
            playerNearbyLeft = false;
            leftDone = true;
            oneRoundCount++;
        }

    }
    public void checkRU(InputAction.CallbackContext context)
    {
        if (playerNearbyRight && Right.transform.eulerAngles.z == 180)
        {
            oneRoundCount++;
            playerNearbyRight = false;
            leftDone = true;

        }

    }
    public void checkLD(InputAction.CallbackContext context)
    {
        if (playerNearbyLeft && Left.transform.eulerAngles.z == 0)
        {
            oneRoundCount++;
            playerNearbyLeft = false;

        }
    }

    public void checkRD(InputAction.CallbackContext context)
    {
        if (playerNearbyRight && Right.transform.eulerAngles.z == 0)
        {
            oneRoundCount++;
            playerNearbyRight = false;
            rightDone = true;


        }
    }

}
