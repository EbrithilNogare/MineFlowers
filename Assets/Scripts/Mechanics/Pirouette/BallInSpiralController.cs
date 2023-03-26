using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallInSpiralController : MonoBehaviour
{
    private Vector2 moveVector = Vector2.zero;
    private Rigidbody2D sphereRigidBody = null;
    MechanicsControls mechanicsConstrolsActions = null;
    float speed = 50f;

    private void Awake()
    {
        sphereRigidBody = GetComponent<Rigidbody2D>();
        mechanicsConstrolsActions = new MechanicsControls();



    }

    private void OnEnable()
    {
        mechanicsConstrolsActions.Enable();
        mechanicsConstrolsActions.Pirouette.Move.performed += Move_performed;
        mechanicsConstrolsActions.Pirouette.Move.canceled += Move_canceled;

    }

    private void OnDisable()
    {
        mechanicsConstrolsActions.Enable();
        mechanicsConstrolsActions.Pirouette.Move.performed -= Move_performed;
        mechanicsConstrolsActions.Pirouette.Move.canceled -= Move_canceled;
    }

    private void FixedUpdate()
    {
        sphereRigidBody.velocity = moveVector * speed;
    }
    private void Move_performed(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();

    }
    private void Move_canceled(InputAction.CallbackContext context)
    {
        moveVector = Vector2.zero;

    }
}
