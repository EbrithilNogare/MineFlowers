using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceMechanics : MonoBehaviour
{
    public GameObject leftArrow;
    public GameObject rightArrow;

    private float movingIndex = 500f;

    bool moving = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
            move();
    }

    private void move()
    {
        Vector3 movingDirection = new Vector3(movingIndex, 0, 0);
        Vector3 middleWall = new Vector3(-50, leftArrow.transform.position.y, 0);
        leftArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(movingIndex, 0);
        rightArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-movingIndex, 0);

    }

}
