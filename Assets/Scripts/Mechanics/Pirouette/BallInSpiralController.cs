using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallInSpiralController : MonoBehaviour
{
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D sphereRigidBody = null;
    float speed = 50f;

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
