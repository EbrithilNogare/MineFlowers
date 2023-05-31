using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateArrows : MonoBehaviour
{

    public GameObject LeftArrow;
    public GameObject RightArrow;


    int randomNumber;
    int angle = 180;
    // Start is called before the first frame update
    void Start()
    {
        generateArrows(LeftArrow);
        generateArrows(RightArrow);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void generateArrows(GameObject image)
    {
        randomNumber = Random.Range(0, 2);
        image.transform.eulerAngles = new Vector3(0, 0, angle * randomNumber);
    }
}
