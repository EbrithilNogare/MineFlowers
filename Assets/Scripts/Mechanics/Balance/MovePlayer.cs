using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{

    #region [SerializeField] public GameObject FinishTrigger { get; }

    [SerializeField]
    [Tooltip("TODO")]
    private GameObject _FinishTrigger;

    /// <summary>
    /// TODO
    /// </summary>
    public GameObject FinishTrigger => _FinishTrigger;

    #endregion

    #region [SerializeField] public GameObject Player { get; }

    [SerializeField]
    private GameObject _Player;

    /// <summary>
    /// TODO
    /// </summary>
    public GameObject Player => _Player;

    #endregion


    #region [SerializeField] public GameObject Canvas { get; }

    [SerializeField]
    [Tooltip("TODO")]
    private GameObject _Canvas;

    /// <summary>
    /// TODO
    /// </summary>

    #endregion

    public enum State
    {
        moving,
        playing,
        notInGame,
    }

    private Vector3 targetPosition;
    private Quaternion playerStartRotation;
    private float progress;

    [HideInInspector]
    public State state;
    [HideInInspector]
    public int currentSegment;

    public GameObject Canvas => _Canvas;
    public float duration = 5; // in seconds
    public int numberOfSegments = 5; // 5 segments = 4 pauses


    private void Start()
    {
        targetPosition = FinishTrigger.transform.position;
        Restart();
    }

    private void Restart()
    {
        state = State.notInGame;
        progress = 0;
        currentSegment = 0;
    }

    private void RestartInputs(bool miniGameInputs)
    {
        if (miniGameInputs)
        {
            Player.transform.GetComponent<PlayerInput>().enabled = !miniGameInputs;
            gameObject.GetComponent<PlayerInput>().enabled = miniGameInputs;
        }
        else
        {
            gameObject.GetComponent<PlayerInput>().enabled = miniGameInputs;
            Player.transform.GetComponent<PlayerInput>().enabled = !miniGameInputs;
        }
        Canvas.SetActive(miniGameInputs);
        Player.transform.GetComponent<ThirdPersonController>().enabled = !miniGameInputs;
    }

    public void Update()
    {
        if (state == State.moving)
        {
            progress += Time.deltaTime / duration;
            if (progress >= 1)
            {
                // end minigame
                RestartInputs(false);
                Restart();
            }
            else if (progress * numberOfSegments > currentSegment)
            {
                // do minigame
                state = State.playing;
            }
            else
            {
                // make a step
                Player.transform.position = Vector3.Lerp(transform.position, targetPosition, progress);
                // targetPosition.y = Player.transform.position.y;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        RestartInputs(true);
        // playerStartRotation = Player.transform.rotation;
    }
}
