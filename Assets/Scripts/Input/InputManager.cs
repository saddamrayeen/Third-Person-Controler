using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerAnimatorController animatorController;
    float moveAmount;
    PlayerControls playerControls;

    public Vector2 movementInput;
    public float verticleInput,
        horizontlInput;

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
        verticleInput = movementInput.y;
        horizontlInput = movementInput.x;
    }
}
