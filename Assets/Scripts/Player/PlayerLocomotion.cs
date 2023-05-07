using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField]
    float moveSpeed;

    Vector3 moveDirection;

    Rigidbody myBody;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        myBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        inputManager.HandleMovementInput();
        moveDirection.z = inputManager.verticleInput;
        moveDirection.x = inputManager.horizontlInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection *= moveSpeed;

        Vector3 movementVelocity = moveDirection;

        myBody.velocity = movementVelocity;
    }
}
