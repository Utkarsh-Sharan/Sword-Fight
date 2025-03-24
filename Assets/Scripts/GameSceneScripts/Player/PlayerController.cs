using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    //Scripts
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private PlayerStateMachine _playerStateMachine;
    private EventService _eventService;
    //Components
    private CharacterController _characterController;
    private Animator _playerAnimator;
    //Input & movement
    private Vector3 _movement, _direction;
    private float _horizontalInput, _verticalInput;
    private float _verticalVelocity;
    private float _turnSmoothVelocity;
    private Vector3 _movementVelocity;
    //SOs
    private EnemyScriptableObject _enemySO;
    private PlayerScriptableObject _playerSO;

    public void Init(CharacterController characterController, Animator playerAnimator, PlayerScriptableObject playerSO)
    {
        _characterController = characterController;
        _playerAnimator = playerAnimator;
        _playerSO = playerSO;

        _playerModel = new PlayerModel(_playerSO);
        _playerView = Object.Instantiate(_playerSO.PlayerView);
        _playerView.SetController(this);

        _playerStateMachine = new PlayerStateMachine(this);
        _playerStateMachine.ChangeState(States.Idle);
    }

    public void Dependency(EnemyService enemyService, EventService eventService)
    {
        _enemySO = enemyService.GetEnemySO(enemyService.GetEnemyType());
        _eventService = eventService;
    }

    public void FixedUpdatePlayer()
    {
        _movement = CalculateMovement(_playerView.transform, _characterController.isGrounded);//
        _playerView.transform.rotation = CalculateRotation(_direction, _playerView.transform.eulerAngles.y);//

        _characterController.Move(_movement);
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
    public void OnDamage() => OnDamage(_enemySO.AttackDamage);

    public void OnDamage(int damageAmount)
    {
        int currentHealth = _playerModel.CurrentHealth;
        _playerModel.CurrentHealth -= damageAmount;

        CheckForPlayerDeath();
    }

    private void CheckForPlayerDeath()
    {
        if (_playerModel.CurrentHealth <= 0)
            PlayerDead();
    }

    public void PlayerDead()
    {
        _eventService.OnPlayerDeathEvent.InvokeEvent();
        _playerAnimator.SetTrigger(ConstantStrings.DEATH_PARAMETER);
        Destroy(this);
    }
    #endregion

    #region Getters
    public Transform GetPlayerTransform() => _playerView.transform;//
    public PlayerScriptableObject GetPlayerSO() => _playerSO;
    public Vector3 GetPlayerMovement() => _movement;
    public Animator GetPlayerAnimator() => _playerAnimator;
    public CharacterController GetCharacterController() => _characterController;
    #endregion
}
