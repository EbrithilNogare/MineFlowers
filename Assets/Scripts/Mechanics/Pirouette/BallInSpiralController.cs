using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallInSpiralController : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject Finish;
    public float speed = 20;

    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D sphereRigidBody = null;

    private void Start()
    {
        speed *= Vector3.Distance(Enemy.transform.position, Finish.transform.position);
    }

    private void Awake()
    {
        sphereRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {

    }

    private void FixedUpdate()
    {
        sphereRigidBody.velocity = moveVector * speed;


    }
    public void Move(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }
}
