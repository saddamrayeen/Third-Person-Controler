using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerAnimatorController animatorController;
    float moveAmount;
    PlayerControls playerControls;

    // for movement
    public Vector2 movementInput;
    public float verticleInput,
        horizontlInput;

    // for camera
    public Vector2 cameraInput;
    public float cameraInputX,
        cameraInputY;

    private void Awake()
    {
        animatorController = GetComponent<PlayerAnimatorController>();
    }

    // when script is enable
    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.Movement.Move.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.Movement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // this method is for handling all processes
    public void HandleAllInputs()
    {
        HandleMovementInput();
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontlInput) + Mathf.Abs(verticleInput));
        animatorController.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandleMovementInput()
    {
        // for camera
        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        //for player
        verticleInput = movementInput.y;
        horizontlInput = movementInput.x;
    }
}
