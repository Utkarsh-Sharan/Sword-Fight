public class IdleState<T> : IState<T> where T : class
{
    public T Owner { get; set; }

    private GenericStateMachine<T> _stateMachine;
    private PlayerController _playerController;

    public IdleState(GenericStateMachine<T> stateMachine)
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
        if (_playerController.GetPlayerMovement().magnitude > 0f)
            _stateMachine.ChangeState(States.Running);
    }

    public void OnStateExit()
    {
        _playerController = null;
    }
}
