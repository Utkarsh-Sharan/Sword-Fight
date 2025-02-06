using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private float horizontalInput;
    private float verticalInput;
    private float moveSpeed = 5f;
    private float verticalVelocity;
    private float gravity = -9.8f;
    private Vector3 movementVelocity;
    private PlayerModel playerModel;

    public void Init(CharacterController characterController)
    {
        this.characterController = characterController;
    }

    private void Start()
    {
        playerModel = new PlayerModel();
    }

    private void FixedUpdate()
    {
        Vector3 movement = playerModel.CalculateMovement(horizontalInput, verticalInput);
        CalculateRotation();
        CheckPlayerGrounded();

        characterController.Move(movement);
    }

    private void CalculateRotation()
    {
        if(movementVelocity != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(movementVelocity);
    }

    private void CheckPlayerGrounded()
    {
        if (!characterController.isGrounded)
            verticalVelocity = gravity;
        else
            verticalVelocity = gravity * 0.3f;

        movementVelocity += verticalVelocity * Vector3.up * Time.deltaTime;
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
