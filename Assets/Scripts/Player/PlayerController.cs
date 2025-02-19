using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator playerAnimator;
    private PlayerModel playerModel;
    private Vector3 movement;
    private Vector3 direction;
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

        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
        }

        characterController.Move(movement);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        playerAnimator.SetFloat(ConstantStrings.PlayerRunParameter, movement.magnitude);
        playerAnimator.SetBool(ConstantStrings.PlayerAirBourneParameter, !characterController.isGrounded);
    }

    private void OnDisable()
    {
        horizontalInput = 0f;
        verticalInput = 0f;
    }
}
