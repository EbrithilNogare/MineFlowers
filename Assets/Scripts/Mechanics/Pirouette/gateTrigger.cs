using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class gateTrigger : MonoBehaviour
{
    bool clear = false;
    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void checkAndClearPath(string input)
    {
        Debug.Log(this.transform.GetChild(index).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text);
        clear = this.transform.GetChild(index).transform.GetChild(0).GetComponent<gateClear>().GetClearVal();
        Debug.Log("CONTROLLER: " + input + " ||| " + clear);
        if (clear && (this.transform.GetChild(index).transform.GetChild(1).GetComponent<TextMeshProUGUI>().text == input))
        {
            this.transform.GetChild(index).gameObject.SetActive(false);
            index++;
        }
    }
}
