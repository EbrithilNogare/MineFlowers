using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class finishTrigger : MonoBehaviour
{
    public GameObject canvas;
    public GameObject playerHuman;
    public GameObject imaginationController;
    public spiralMinigameHandler minigame;

    #region [SerializeField] public AudioSource finishAudio { get; }

    [SerializeField]
    private AudioSource _finishAudio;

    /// <summary>
    /// TODO
    /// </summary>
    public AudioSource finishAudio => _finishAudio;

    #endregion


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
            PlaySoundInterval(0, 3f);
            minigame.minigameOn = false;
            canvas.SetActive(false);
            playerHuman.transform.GetComponent<PlayerInput>().enabled = true;
            imaginationController.GetComponent<RealityAwareness>().awareness = 1f;
        }
    }

    void PlaySoundInterval(float fromSeconds, float toSeconds)
    {
        finishAudio.time = fromSeconds;
        finishAudio.Play();
        finishAudio.SetScheduledEndTime(AudioSettings.dspTime + (toSeconds - fromSeconds));
    }
}
