using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator playerAnimator;
    private PlayerModel playerModel;
    private Vector3 movement;
    private float horizontalInput;
    private float verticalInput;

    public void Init(CharacterController characterController, Animator playerAnimator)
    {
        this.characterController = characterController;
        this.playerAnimator = playerAnimator;
    }

    private void Start()
    {
        playerModel = new PlayerModel();
    }

    private void FixedUpdate()
    {
        movement = playerModel.CalculateMovement(horizontalInput, verticalInput, characterController.isGrounded);
        characterController.Move(movement);

        Quaternion targetRotation = playerModel.GetTargetRotation();
        if(targetRotation != Quaternion.identity)
            transform.rotation = targetRotation;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        playerAnimator.SetFloat(ConstantStrings.PlayerRunParameter, movement.magnitude);
        playerAnimator.SetBool(ConstantStrings.PlayerAirBourneParameter, !characterController.isGrounded);
    }

    private void OnDisable()
    {
        horizontalInput = 0f;
        verticalInput = 0f;
    }
}
