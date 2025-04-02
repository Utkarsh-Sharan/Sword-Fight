using UnityEngine;
using Cinemachine;

public class PlayerController
{
    //Scripts
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private PlayerStateMachine _playerStateMachine;
    //Input & movement
    private Vector3 _movement, _direction;
    private float _horizontalInput, _verticalInput;
    private float _verticalVelocity;
    private float _turnSmoothVelocity;
    private Vector3 _movementVelocity;
    //SO
    private PlayerScriptableObject _playerSO;
    //Virtual camera
    private CinemachineVirtualCamera _playerFollowVCam;

    public PlayerController(PlayerScriptableObject playerSO)
    {
        _playerSO = playerSO;

        SetModelAndView(_playerSO);
        SetPlayerFollowVirtualCamera();
        SetStateMachine();

        EventService.Instance.OnGetPlayerTransformEvent.AddListener(GetPlayerTransform);
    }

    private void SetModelAndView(PlayerScriptableObject playerSO)
    {
        _playerModel = new PlayerModel(_playerSO);
        _playerView = Object.Instantiate(_playerSO.PlayerView);
        _playerView.Initialize(this);
    }

    private void SetPlayerFollowVirtualCamera()
    {
        _playerFollowVCam = Object.Instantiate(_playerSO.VCamStats.VirtualCamera);
        _playerFollowVCam.transform.position = _playerSO.VCamStats.VCamPosition;
        _playerFollowVCam.transform.rotation = _playerSO.VCamStats.VCamRotation;
        _playerFollowVCam.Follow = _playerView.transform;
        _playerFollowVCam.LookAt = _playerView.transform;
    }

    private void SetStateMachine()
    {
        _playerStateMachine = new PlayerStateMachine(this);
        _playerStateMachine.ChangeState(States.Idle);
    }

    public void FixedUpdatePlayer()
    {
        _movement = CalculateMovement(_playerView.transform, GetCharacterController().isGrounded);
        _playerView.transform.rotation = CalculateRotation(_direction, _playerView.transform.eulerAngles.y);

        GetCharacterController().Move(_movement);
    }

    public void UpdatePlayer()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(_horizontalInput, 0, _verticalInput).normalized;
        _playerStateMachine.Update();
    }

    #region Movement and Rotation Calculation
    private Vector3 CalculateMovement(Transform playerTransform, bool isGrounded)
    {
        _movementVelocity.Set(_horizontalInput, 0, _verticalInput);
        _movementVelocity.Normalize();
        _movementVelocity *= _playerModel.GetMoveSpeed() * Time.deltaTime;

        _verticalVelocity = isGrounded ? _playerModel.GetGravity() * 0.3f : _playerModel.GetGravity();
        _movementVelocity += _verticalVelocity * Vector3.up * Time.deltaTime;

        return _movementVelocity;
    }

    public Quaternion CalculateRotation(Vector3 direction, float currentYRotation)
    {
        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(currentYRotation, targetAngle, ref _turnSmoothVelocity, _playerModel.GetTurnSmoothTime());
            return Quaternion.Euler(0, angle, 0);
        }

        return Quaternion.Euler(0, currentYRotation, 0);
    }
    #endregion

    #region Health and Damage Handling
    public void OnDamage(int damageAmount)
    {
        _playerModel.CurrentHealth -= damageAmount;
        CheckForPlayerDeath();
    }

    private void CheckForPlayerDeath()
    {
        if (_playerModel.CurrentHealth <= 0)
            _playerView.PlayerDead();
    }
    #endregion

    #region Getters
    public Transform GetPlayerTransform() => _playerView.transform;
    public PlayerScriptableObject GetPlayerSO() => _playerSO;
    public Vector3 GetPlayerMovement() => _movement;
    public Animator GetPlayerAnimator() => _playerView.GetPlayerAnimator();
    public CharacterController GetCharacterController() => _playerView.GetCharacterController();
    #endregion

    public void RemoveListeners()
    {
        EventService.Instance.OnGetPlayerTransformEvent.RemoveListener(GetPlayerTransform);
    }
}
