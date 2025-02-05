using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    private float horizontalInput;
    private float verticalInput;
    private float moveSpeed = 5f;
    private Vector3 movementVelocity;

    private void FixedUpdate()
    {
        CalculateMovement();
        characterController.Move(movementVelocity);
    }

    private void CalculateMovement()
    {
        movementVelocity.Set(horizontalInput, 0, verticalInput);
        movementVelocity.Normalize();
        movementVelocity = Quaternion.Euler(0, -45f, 0) * movementVelocity;
        movementVelocity *= moveSpeed * Time.deltaTime;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void OnDisable()
    {
        horizontalInput = 0f;
        verticalInput = 0f;
    }
}
