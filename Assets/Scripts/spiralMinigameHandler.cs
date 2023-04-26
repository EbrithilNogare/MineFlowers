using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiralMinigameHandler : MonoBehaviour
{
    public GameObject playerBall;
    public GameObject enemyBall;
    public GameObject gates;
    public GameObject finish;

    public float spinSpeed;

    private Vector3 resetStartPositionPlayer;
    private Vector3 resetStartPositionEnemy;

    public bool minigameOn;
    private void Start()
    {
        resetStartPositionPlayer = playerBall.transform.localPosition;
        resetStartPositionEnemy = enemyBall.transform.localPosition;
    }

    private void Update()
    {
        float enemyDistanceToFin = Vector3.Distance(enemyBall.transform.position, finish.transform.position);
        float playerDistanceToFin = Vector3.Distance(playerBall.transform.position, finish.transform.position);
        float distanceDifference = enemyDistanceToFin - playerDistanceToFin;
        float wholeDifference = Vector3.Distance(resetStartPositionEnemy, finish.transform.position);
        Debug.Log("wholeDifference: " + wholeDifference);
        spinSpeed = Mathf.Lerp(0.3f, 2f, distanceDifference / wholeDifference);
    }

    private void OnEnable()
    {
        minigameOn = true;
        for (int i = 0; i < gates.transform.childCount; i++)
        {
            gates.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    private void OnDisable()
    {
        enemyBall.transform.localPosition = resetStartPositionEnemy;
        enemyBall.transform.GetComponent<EnemyStalkerController>().duration = 20;
        playerBall.transform.localPosition = resetStartPositionPlayer;
    }

}
