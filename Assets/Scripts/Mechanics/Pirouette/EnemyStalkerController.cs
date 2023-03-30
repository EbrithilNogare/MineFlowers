using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemyStalkerController : MonoBehaviour
{
    public float moveSpeed = 100f;
    public float leadDistance = 50f;
    public Vector2 endPosition;


    private Vector3 startPosition;
    private Vector3 realEndPosition;
    private CircleCollider2D enemyCollider;

    public GameObject player;

    void Start()
    {
        startPosition = transform.localPosition;

        transform.localPosition = endPosition;
        realEndPosition = transform.position;
        transform.localPosition = startPosition;

        enemyCollider = this.GetComponent<CircleCollider2D>();
        enemyCollider.enabled = true;
    }

    void Update()
    {
        float angle = moveSpeed * Time.deltaTime;
        float wholeDistance = Vector3.Distance(startPosition, endPosition);
        float remainingDistance = Vector3.Distance(transform.localPosition, endPosition);
        if (remainingDistance > .01)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPosition, angle / 360 / 3 * wholeDistance / remainingDistance);
            transform.RotateAround(realEndPosition, Vector3.forward, -angle / remainingDistance);
        }

    }

    private void OnTriggerEnter2D()
    {

        Debug.Log("You lost!");

    }

}