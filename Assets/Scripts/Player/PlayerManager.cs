using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        // calling this method to update all input managers variables and handlings
        inputManager.HandleAllInputs();
    }

    private void FixedUpdate()
    {
        // calling this method to update all player movements and handlings
        playerLocomotion.HandleAllMovements();
    }
}
