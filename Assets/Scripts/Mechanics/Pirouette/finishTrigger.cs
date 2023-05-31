using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class finishTrigger : MonoBehaviour
{
    public GameObject canvas;
    public GameObject playerHuman;
    public GameObject imaginationController;
    public spiralMinigameHandler minigame;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D triggerer)
    {
        if (triggerer.tag == "Player")
        {
            Debug.Log("You won!");
            minigame.minigameOn = false;
            canvas.SetActive(false);
            playerHuman.transform.GetComponent<PlayerInput>().enabled = true;
            imaginationController.GetComponent<RealityAwareness>().awareness = math.clamp(imaginationController.GetComponent<RealityAwareness>().awareness + 0.3f, 0, 1);
        }
    }
}
