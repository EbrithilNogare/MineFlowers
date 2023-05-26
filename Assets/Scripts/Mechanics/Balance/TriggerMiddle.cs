using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TriggerMiddle : MonoBehaviour
{
    public GameObject GenerateParent;
    public GameObject Left;
    public GameObject Right;
    public GameObject Canvas;

    Vector3 startPositionLeftArrow;
    Vector3 startPositionRightArrow;

    private Vector3 up = new Vector3(0, 0, 0);
    private Vector3 down = new Vector3(0, 0, -180);

    private bool playerNearbyLeft = false;
    private bool playerNearbyRight = false;

    private int winCount = 0;
    private int oneRoundCount = 0;

    private const int numOfRounds = 5;

    // Start is called before the first frame update
    void Start()
    {
        startPositionLeftArrow = Left.transform.position;
        startPositionRightArrow = Right.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetPositions();
    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    ResetPositions();
    //    if (oneRoundCount == 2)
    //        winCount++;
    //    if (winCount == numOfRounds)
    //        Canvas.SetActive(false);
    //    oneRoundCount = 0;
    //}

    public void ResetPositions()
    {
        Left.transform.position = startPositionLeftArrow;
        Right.transform.position = startPositionRightArrow;
        GenerateParent.GetComponent<GenerateArrows>().generateArrows(Left);
        GenerateParent.GetComponent<GenerateArrows>().generateArrows(Right);
    }

    //public void checkLU(InputAction.CallbackContext context)
    //{
    //    //Debug.Log("check");
    //    if (playerNearbyLeft && Left.transform.localEulerAngles.z == 180)
    //    {
    //        Debug.Log("YES_LEFT");
    //        playerNearbyLeft = false;
    //        oneRoundCount++;
    //    }

    //}
    //public void checkRU(InputAction.CallbackContext context)
    //{
    //    //Debug.Log("check");
    //    if (playerNearbyRight && Right.transform.eulerAngles.z == 180)
    //    {
    //        Debug.Log("YES_RIGHT");
    //        oneRoundCount++;
    //        playerNearbyRight = false;

    //    }

    //}
    //public void checkLD(InputAction.CallbackContext context)
    //{
    //    //Debug.Log("check");
    //    if (playerNearbyLeft && Left.transform.eulerAngles.z == 0)
    //    {
    //        Debug.Log("YES_LEFT");
    //        oneRoundCount++;
    //        playerNearbyLeft = false;

    //    }
    //}

    //public void checkRD(InputAction.CallbackContext context)
    //{
    //    //Debug.Log("check");
    //    if (playerNearbyRight && Right.transform.eulerAngles.z == 0)
    //    {
    //        Debug.Log("YES_RIGHT");
    //        oneRoundCount++;
    //        playerNearbyRight = false;

    //    }
    //}
}
