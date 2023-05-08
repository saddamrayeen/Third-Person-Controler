using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{
    InputManager inputManager;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float rotationSpeed;

    Vector3 moveDirection;

    Rigidbody myBody;

    Transform cameraObject;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        myBody = GetComponent<Rigidbody>();
        cameraObject = Camera.main.transform;
    }

    // this method is for handling all processes
    public void HandleAllMovements()
    {
        MovePlayer();
        RotatePlayer();
    }

    //moving player
    private void MovePlayer()
    {
        // getting axis valus from input manager to move the player
        moveDirection = cameraObject.forward *  inputManager.verticleInput;
        moveDirection +=  cameraObject.right* inputManager.horizontlInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection *= moveSpeed;

        Vector3 movementVelocity = moveDirection;

        myBody.velocity = movementVelocity;
    }

    // rotating player
    private void RotatePlayer()
    {
        Vector3 rotationDirection = new Vector3();

        rotationDirection = cameraObject.forward * inputManager.verticleInput;
        rotationDirection += cameraObject.right * inputManager.horizontlInput;

        rotationDirection.Normalize();
        rotationDirection.y = 0;
        
        if (rotationDirection == Vector3.zero)
            rotationDirection = transform.forward;

        var targetRotation = Quaternion.LookRotation(rotationDirection);

        var playerRotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );
        transform.rotation = playerRotation;
    }
}