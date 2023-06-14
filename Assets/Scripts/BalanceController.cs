using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BalanceController : MonoBehaviour
{
    [Header("======== Public ========")]
    public GameObject player;
    [Tooltip("in seconds")]
    public float duration = 2f;
    public float playerSpeed = 1f;
    [Header("======== Bottom bar ========")]
    public GameObject leftPart;
    public GameObject rightPart;
    public GameObject leftStart;
    public GameObject rightStart;
    public GameObject leftFinish;
    public GameObject rightFinish;
    [Header("======== Pictures ========")]
    public Texture2D leftPictureUp;
    public Texture2D rightPictureUp;
    public Texture2D leftPictureDown;
    public Texture2D rightPictureDown;

    private GameObject startPosition;
    private GameObject endPosition;
    private bool playing = false;
    private string[] lastKeys = new string[2];
    private string[] correctKeys = new string[2];
    private float arrowsProgress = 0f;
    private int iterationsCount = 5;
    private float currentIteration = 0;

    // Start is called before the first frame update
    void Start()
    {
        resetMinigame();
    }

    private void OnEnable()
    {
        playing = true;
        resetMinigame();
        updateInputSystem(true);
    }
    private void OnDisable()
    {
        playing = false;
        resetMinigame();
        updateInputSystem(false);
    }

    public void initNewMinigame(GameObject _startPosition, GameObject _endPosition)
    {
        startPosition = _startPosition;
        endPosition = _endPosition;

        currentIteration = 0;
        playing = true;
        resetMinigame();
        updateInputSystem(true);
    }

    void Update()
    {
        // make move
        if (playing)
        {
            Vector3 actualPosition = player.transform.position;
            Vector3 finalPosition = Vector3.Lerp(startPosition.transform.position, endPosition.transform.position, currentIteration);
            float maxDistance = playerSpeed * Time.deltaTime;
            player.transform.position =
            Vector3.MoveTowards(actualPosition, finalPosition, maxDistance);
            player.GetComponent<Animator>().SetFloat("Speed", Vector3.Distance(actualPosition, finalPosition) > .001f ? 2 * playerSpeed : 0);


            arrowsProgress += Time.deltaTime / duration;
            leftPart.transform.position = Vector3.Lerp(leftStart.transform.position, leftFinish.transform.position, arrowsProgress);
            rightPart.transform.position = Vector3.Lerp(rightStart.transform.position, rightFinish.transform.position, arrowsProgress);
        }

        // reset game
        if (arrowsProgress >= 1)
        {
            // evaluate
            if (lastKeys[0] == correctKeys[0] && lastKeys[1] == correctKeys[1])
            {
                onMinigameSuccess();
            }
            else
            {
                onMinigameError();
            }

            // reset
            resetMinigame();
        }
    }

    void onMinigameSuccess()
    {
        Debug.Log("onMinigameSuccess ");
        currentIteration += 1f / ((float)iterationsCount);
        if (currentIteration >= 1)
        {
            Debug.Log("onMinigameWin");

            startPosition.GetComponent<CapsuleCollider>().enabled = false;
            gameObject.SetActive(false);
        }
    }

    void onMinigameError()
    {
        Debug.Log("onMinigameError");
    }


    void resetMinigame()
    {
        //reset last pressed
        lastKeys[0] = "";
        lastKeys[1] = "";

        arrowsProgress = 0;

        // choose random sequence
        int randomSequence = (int)Random.Range(0, 4);

        if (randomSequence % 2 == 0)
        {
            correctKeys[0] = "UP"; // left
            leftPart.GetComponent<RawImage>().texture = leftPictureUp;
        }
        else
        {
            correctKeys[0] = "DOWN"; // left
            leftPart.GetComponent<RawImage>().texture = leftPictureDown;
        }

        if (randomSequence < 2)
        {
            correctKeys[1] = "UP"; // right
            rightPart.GetComponent<RawImage>().texture = rightPictureUp;
        }
        else
        {
            correctKeys[1] = "DOWN"; // right
            rightPart.GetComponent<RawImage>().texture = rightPictureDown;
        }

        // reset arrows to start position
        leftPart.transform.position = leftStart.transform.position;
        rightPart.transform.position = rightStart.transform.position;
    }

    void updateInputSystem(bool minigame)
    {
        if (minigame)
        {
            player.GetComponent<PlayerInput>().enabled = false;
            gameObject.GetComponent<PlayerInput>().enabled = true;
            player.GetComponent<Animator>().SetFloat("Speed", 0);
            player.GetComponent<Animator>().SetBool("Jump", false);
            player.GetComponent<Animator>().SetBool("Grounded", true);
            player.GetComponent<Animator>().SetBool("FreeFall", false);
        }
        else
        {
            gameObject.GetComponent<PlayerInput>().enabled = false;
            player.GetComponent<PlayerInput>().enabled = true;
        }

        player.transform.GetComponent<ThirdPersonController>().enabled = !minigame;
    }


    public void leftCallbackKey(string direction)
    {
        lastKeys[0] = direction;
    }

    public void rightCallbackKey(string direction)
    {
        lastKeys[1] = direction;
    }

}
