using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private float horizontalInput;
    private float verticalInput;
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
        Vector3 movement = playerModel.CalculateMovement(horizontalInput, verticalInput, characterController.isGrounded);
        characterController.Move(movement);

        Quaternion targetRotation = playerModel.GetTargetRotation();
        if(targetRotation != Quaternion.identity)
            transform.rotation = targetRotation;
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
