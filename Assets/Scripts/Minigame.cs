using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Minigame : MonoBehaviour
{

    public GameObject minigamePanel;
    public GameObject Player;
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
        Debug.Log("minigame enter");
        Player.transform.GetComponent<PlayerInput>().enabled = false;
        minigamePanel.SetActive(true);
    }
}
