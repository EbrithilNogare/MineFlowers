using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemyStalkerController : MonoBehaviour
{
    public float duration = 5;
    public GameObject Finish;
    public GameObject canvas;
    public GameObject gates;

    private Vector3 localStartPosition;
    private Vector3 globalStartPosition;
    private Vector3 localEndPosition;
    private Vector3 globalEndPosition;
    private float wholeDistance;
    private Vector3 resetStartPositionPlayer;
    private const float turns = 3;

    public GameObject player;

    void Start()
    {
        resetStartPositionPlayer = player.transform.localPosition;

        localStartPosition = transform.localPosition;
        globalStartPosition = transform.position;
        localEndPosition = Finish.transform.localPosition;
        globalEndPosition = Finish.transform.position;

        wholeDistance = Vector3.Distance(localStartPosition, localEndPosition);
    }

    void Update()
    {
        float angle = turns * 360 * Time.deltaTime / duration;
        float distance = wholeDistance * Time.deltaTime / duration;
        float remainingDistance = Vector3.Distance(transform.localPosition, localEndPosition);
        float angleSpeedFix = wholeDistance / remainingDistance;
        if (remainingDistance > .001)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, localEndPosition, distance * angleSpeedFix);
            transform.RotateAround(globalEndPosition, Vector3.forward, -angle * angleSpeedFix);
        }


    }

    private void OnTriggerEnter2D()
    {

        Debug.Log("You lost!");
        //canvas.SetActive(false);
        transform.localPosition = localStartPosition;
        player.transform.localPosition = resetStartPositionPlayer;
        duration *= 1.1f;

        for (int i = 0; i < gates.transform.childCount; i++)
        {
            gates.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

}