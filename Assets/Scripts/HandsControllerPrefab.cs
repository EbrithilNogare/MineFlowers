using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.InputSystem;


public class HandsControllerPrefab : MonoBehaviour
{
    public HandsController2 controls;
    public GameObject rHandTarget;
    public GameObject lHandTarget;
    public GameObject HandsIKRig;
    
    private void Start()
    {
        controls = new HandsController2();
        var rig = HandsIKRig.GetComponent<Rig>();
        rig.weight = 0;
        controls.Hands.Righthandup.performed += context => MoveRightTargetUp();
        controls.Hands.Righthanddown.performed += context => MoveRightTargetDown();
        controls.Hands.Lefthandup.performed += context => MoveLeftTargetUp();
        controls.Hands.Lefthanddown.performed += context => MoveLeftTargetDown();
    }
    
    
    private void OnEnable()
    {
        controls?.Enable();
    }

    private void OnDisable()
    {
        controls?.Disable();
    }
    
    public void EnableControls()
    {
        Debug.Log("enabled");
        controls.Enable();
        var rig = HandsIKRig.GetComponent<Rig>();
        rig.weight = 1;
    }
    
    public void DisableControls()
    {
        Debug.Log("disabled");
        controls.Disable();
        var rig = HandsIKRig.GetComponent<Rig>();
        rig.weight = 0;
    }
    
    void MoveRightTargetUp()
    {
        Vector3 currentPosition = rHandTarget.transform.localPosition;
        currentPosition.y += 0.1f;
        rHandTarget.transform.localPosition = currentPosition;
    }
    
    void MoveRightTargetDown()
    {
        Vector3 currentPosition = rHandTarget.transform.localPosition;
        currentPosition.y -= 0.1f;
        rHandTarget.transform.localPosition = currentPosition;
    }
    
    void MoveLeftTargetUp()
    {
        Vector3 currentPosition = lHandTarget.transform.localPosition;
        currentPosition.y += 0.1f;
        lHandTarget.transform.localPosition = currentPosition;
    }
    void MoveLeftTargetDown()
    {
        Vector3 currentPosition = lHandTarget.transform.localPosition;
        currentPosition.y -= 0.1f;
        lHandTarget.transform.localPosition = currentPosition;
    }
}
