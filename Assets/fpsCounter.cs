using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class fpsCounter : MonoBehaviour
{
    private float[] timings = new float[100];
    private int timingsIndex = 0;
    private float timingSum = 0;

    public GameObject canvasText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timingSum -= timings[timingsIndex];
        timings[timingsIndex] = Time.deltaTime;
        timingSum += timings[timingsIndex];

        if (timingsIndex % 10 == 0)
        {
            float highest = timings[0];
            foreach (float item in timings)
            {
                if(item > highest)
                    highest = item;
            }
            
            canvasText.GetComponent<TMP_Text>().text = String.Format("FPS: {0:0.00}\nAVG 100: {1:0.00}\n99 % LOW: {2:0.00}", 1/timings[timingsIndex], 100/timingSum, 1 / highest);
        }

        timingsIndex = (timingsIndex + 1) % 100;
    }
}
