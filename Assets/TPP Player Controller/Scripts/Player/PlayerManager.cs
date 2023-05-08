using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;
    CameraManager cameraManager;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        cameraManager = FindObjectOfType<CameraManager>();
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

    private void LateUpdate()
    {
        // this method will set camera to follow the player
        cameraManager.HandleAllCamerUpdates();
    }
}
