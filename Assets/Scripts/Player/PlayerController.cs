using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private Animator _playerAnimator;
    private PlayerModel _playerModel;
    private Vector3 _movement, _direction;
    private float _horizontalInput, _verticalInput;

    private PlayerStateMachine _playerStateMachine;

    public void Init(CharacterController characterController, Animator playerAnimator)
    {
        _characterController = characterController;
        _playerAnimator = playerAnimator;
    }

    private void Start()
    {
        _playerModel = new PlayerModel();
        _playerStateMachine = new PlayerStateMachine(this);

        _playerStateMachine.ChangeState(States.Idle);
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

        //_playerAnimator.SetBool(ConstantStrings.PLAYER_AIRBOURNE_PARAMETER, !_characterController.isGrounded);

        _playerStateMachine.Update();
    }

    public Transform GetPlayerTransform() => this.transform;
    public Vector3 GetPlayerMovement() => this._movement;
    public Animator GetPlayerAnimator() => this._playerAnimator;

    private void OnDisable()
    {
        _horizontalInput = 0f;
        _verticalInput = 0f;
    }
}
