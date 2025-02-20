using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _playerAnimator;
    private PlayerModel _playerModel;
    private Vector3 _movement;
    private Vector3 _direction;
    private float _horizontalInput;
    private float _verticalInput;

    public void Init(CharacterController characterController, Animator playerAnimator)
    {
        this._characterController = characterController;
        this._playerAnimator = playerAnimator;
    }

    private void Start()
    {
        _playerModel = new PlayerModel();
    }

    private void FixedUpdate()
    {
        _movement = _playerModel.CalculateMovement(_horizontalInput, _verticalInput, _characterController.isGrounded);

        transform.rotation = _playerModel.CalculateRotation(_direction, transform.eulerAngles.y);

        _characterController.Move(_movement);
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(_horizontalInput, 0, _verticalInput).normalized;

        _playerAnimator.SetFloat(ConstantStrings.PLAYER_RUN_PARAMETER, _movement.magnitude);
        _playerAnimator.SetBool(ConstantStrings.PLAYER_AIRBOURNE_PARAMETER, !_characterController.isGrounded);
    }

    private void OnDisable()
    {
        _horizontalInput = 0f;
        _verticalInput = 0f;
    }
}
