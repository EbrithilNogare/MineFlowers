using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceConnector : MonoBehaviour
{

    public GameObject balanceController;

    public GameObject startPosition;
    public GameObject endPosition;

    private void OnTriggerEnter(Collider other)
    {
        balanceController.SetActive(true);
        balanceController.GetComponent<BalanceController>().initNewMinigame(startPosition, endPosition);
    }
}
