using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowerCounter : MonoBehaviour
{

    public GameObject flowerCanvasText;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateFlowersCount()
    {
        int count = 0;
        int.TryParse(flowerCanvasText.GetComponent<TMP_Text>().text, out count);
        flowerCanvasText.GetComponent<TMP_Text>().SetText((count+1).ToString());
    }
}
