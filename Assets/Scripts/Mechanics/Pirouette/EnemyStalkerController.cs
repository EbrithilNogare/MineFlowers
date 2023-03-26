using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemyStalkerController : MonoBehaviour
{
    public float moveSpeed = 100f;
    public float leadDistance = 50f;
    public Vector2 endPosition; // -24, -24


    private Vector3 startPosition;
    private Vector3 realEndPosition;
    private PolygonCollider2D enemyCollider;
    private Rigidbody2D playerRb = null;
    private Vector3 customAxis;

    public GameObject player;
    private Vector3 movementVector;

    void Start()
    {
        startPosition = transform.localPosition;

        transform.localPosition = endPosition;
        realEndPosition = transform.position;
        transform.localPosition = startPosition;

        enemyCollider = this.GetComponent<PolygonCollider2D>();
        enemyCollider.enabled = true;
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        const float rotationsCount = 3;
        float angle = moveSpeed * Time.deltaTime;
        float wholeDistance = Vector3.Distance(startPosition, endPosition);
        float remainingDistance = Vector3.Distance(transform.localPosition, endPosition);
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPosition, angle / 360 / 3 * wholeDistance / remainingDistance);
        transform.RotateAround(realEndPosition, Vector3.forward, -angle / remainingDistance);

    }
}