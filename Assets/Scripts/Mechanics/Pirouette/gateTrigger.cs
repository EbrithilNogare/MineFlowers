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

    private void OnEnable()
    {
        generateRandomGateLetter();
        this.transform.GetChild(2).transform.GetComponent<TextMeshProUGUI>().text = correctButton;
    }

    public void checkX(InputAction.CallbackContext context)
    {
        if (playerNearby && "X" == correctButton)
            gameObject.SetActive(false);
    }
    public void checkY(InputAction.CallbackContext context)
    {
        if (playerNearby && "Y" == correctButton)
            gameObject.SetActive(false);
    }

    public void checkA(InputAction.CallbackContext context)
    {
        if (playerNearby && "A" == correctButton)
            gameObject.SetActive(false);
    }

    public void checkB(InputAction.CallbackContext context)
    {
        if (playerNearby && "B" == correctButton)
            gameObject.SetActive(false);
    }



    private void OnTriggerEnter2D()
    {
        playerNearby = true;
    }
    private void OnTriggerExit2D()
    {
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
