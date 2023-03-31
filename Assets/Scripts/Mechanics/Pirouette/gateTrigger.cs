using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class gateTrigger : MonoBehaviour
{
    public bool playerNearby = false;
    public string correctButton = "X";

    public void Start()
    {
        generateRandomGateLetter();
        this.transform.GetChild(2).transform.GetComponent<TextMeshProUGUI>().text = correctButton;
    }

    public void checkX(InputAction.CallbackContext context)
    {
        Debug.Log("check");
        if (playerNearby && "X" == correctButton)
            gameObject.SetActive(false);
    }
    public void checkY(InputAction.CallbackContext context)
    {
        Debug.Log("check");
        if (playerNearby && "Y" == correctButton)
            gameObject.SetActive(false);
    }

    public void checkA(InputAction.CallbackContext context)
    {
        Debug.Log("check");
        if (playerNearby && "A" == correctButton)
            gameObject.SetActive(false);
    }

    public void checkB(InputAction.CallbackContext context)
    {
        Debug.Log("check");
        if (playerNearby && "B" == correctButton)
            gameObject.SetActive(false);
    }



    private void OnTriggerEnter2D()
    {
        Debug.Log("OnTriggerEnter");
        playerNearby = true;
    }
    private void OnTriggerExit2D()
    {
        Debug.Log("OnTriggerExit");
        playerNearby = false;
    }

    private void generateRandomGateLetter()
    {
        int index = Random.Range(0, 4);
        correctButton = ((Buttons)index).ToString();
    }

    enum Buttons
    {
        X, Y, B, A
    }

}
