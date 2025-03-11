public class PlayerAirBourneState<T> : IState<T> where T : class
{
    public T Owner { get ; set ; }

    private GenericStateMachine<T> _stateMachine;
    private PlayerController _playerController;
    private bool _isPlayerGrounded;

    public PlayerAirBourneState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        PlayerController player = Owner as PlayerController;
        _playerController = player;
        _isPlayerGrounded = _playerController.GetCharacterController().isGrounded;
    }

    public void Update()
    {
        if (_playerController.GetCharacterController().isGrounded)
            _stateMachine.ChangeState(States.Idle);

        _playerController.GetPlayerAnimator().SetBool(ConstantStrings.PLAYER_AIRBOURNE_PARAMETER, !_playerController.GetCharacterController().isGrounded);
    }

    public void OnStateExit()
    {
        
    }
}
