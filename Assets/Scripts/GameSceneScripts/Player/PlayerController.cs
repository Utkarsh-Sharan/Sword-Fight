using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    [SerializeField] private DamageApplier _damageApplier;

    private CharacterController _characterController;
    private Animator _playerAnimator;
    private PlayerModel _playerModel;
    private Vector3 _movement, _direction;
    private float _horizontalInput, _verticalInput;

    private PlayerStateMachine _playerStateMachine;

    private EnemyScriptableObject _enemySO;
    private PlayerScriptableObject _playerSO;

    private EventService _eventService;

    public void Init(CharacterController characterController, Animator playerAnimator, PlayerScriptableObject playerSO)
    {
        _characterController = characterController;
        _playerAnimator = playerAnimator;
        _playerSO = playerSO;
    }

    public void Dependency(EnemyService enemyService, EventService eventService)
    {
        _enemySO = enemyService.GetEnemySO(enemyService.GetEnemyType());
        _eventService = eventService;
    }

    private void Start()
    {
        _playerModel = new PlayerModel(this, _playerSO);
        _playerStateMachine = new PlayerStateMachine(this);

        _playerStateMachine.ChangeState(States.Idle);
    }

    private void FixedUpdate()
    {
        _movement = _playerModel.CalculateMovement(this.transform, _horizontalInput, _verticalInput, _characterController.isGrounded);
        transform.rotation = _playerModel.CalculateRotation(_direction, transform.eulerAngles.y);

        _characterController.Move(_movement);
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");

        _direction = new Vector3(_horizontalInput, 0, _verticalInput).normalized;
        _playerStateMachine.Update();
    }

    public void PlayerAttackStart() => _damageApplier.enabled = true;
    public void PlayerAttackEnd() => _damageApplier.enabled = false;

    public Transform GetPlayerTransform() => this.transform;
    public Vector3 GetPlayerMovement() => _movement;
    public Animator GetPlayerAnimator() => _playerAnimator;
    public CharacterController GetCharacterController() => _characterController;
    public PlayerScriptableObject GetPlayerSO() => _playerSO;

    public void OnDamage() => _playerModel.OnDamage(_enemySO.AttackDamage);

    public void PlayerDead()
    {
        _eventService.OnPlayerDeathEvent.InvokeEvent();
        _playerAnimator.SetTrigger(ConstantStrings.DEATH_PARAMETER);
        Destroy(this);
    }
}
