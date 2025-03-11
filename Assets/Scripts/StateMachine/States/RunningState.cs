public class RunningState<T> : IState<T> where T : class
{
    public T Owner { get; set; }

    private GenericStateMachine<T> _stateMachine;
    private PlayerController _playerController;

    public RunningState(GenericStateMachine<T> stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public void OnStateEnter()
    {
        PlayerController player = Owner as PlayerController;
        _playerController = player;
    }

    public void Update()
    {
        if (_playerController.GetPlayerMovement().magnitude <= 0f)
            _stateMachine.ChangeState(States.Idle);

        _playerController.GetPlayerAnimator().SetFloat(ConstantStrings.RUN_PARAMETER, _playerController.GetPlayerMovement().magnitude);
    }

    public void OnStateExit()
    {
        _playerController = null;
    }
}
