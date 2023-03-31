using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gateClear : MonoBehaviour
{
    bool clear = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D par)
    {
        // if (par.tag == "Player")
        //{
        Debug.Log("in");
        clear = true;
        //player.position = new Vector3(x, y, 0.0f);
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("out");
        clear = false;
    }

    public bool GetClearVal() => clear;
}
