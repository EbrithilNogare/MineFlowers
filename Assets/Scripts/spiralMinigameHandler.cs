using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiralMinigameHandler : MonoBehaviour
{
    public GameObject playerBall;
    public GameObject enemyBall;
    public GameObject gates;

    private Vector3 resetStartPositionPlayer;
    private Vector3 resetStartPositionEnemy;

    private void Start()
    {
        resetStartPositionPlayer = playerBall.transform.localPosition;
        resetStartPositionEnemy = enemyBall.transform.localPosition;
    }

    private void OnEnable()
    {
        Debug.Log("Enable!!!");
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
