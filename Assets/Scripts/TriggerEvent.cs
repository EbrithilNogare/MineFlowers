using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{

    public UnityEvent start;
    public UnityEvent triggerEnter;
    public UnityEvent triggerExit;

    // Start is called before the first frame update
    void Start()
    {
        start.Invoke();
    }


    private void OnTriggerEnter(Collider other)
    {
        triggerEnter.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        triggerExit.Invoke();
    }

}
