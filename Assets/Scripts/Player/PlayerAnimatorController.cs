using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void UpdateAnimatorValues(float horizontalMovement, float verticleMovements)
    {
        animator.SetFloat("horizontal", horizontalMovement, 0.1f, Time.deltaTime);
        animator.SetFloat("verticle", verticleMovements, 0.1f, Time.deltaTime);
    }
}
