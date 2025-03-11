public class PlayerRunningState<T> : IState<T> where T : PlayerController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;

    public PlayerRunningState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        
    }

    public void Update()
    {
        if(Owner.GetPlayerMovement().magnitude <= 0f)
            _stateMachine.ChangeState(States.Idle);
        if(!Owner.GetCharacterController().isGrounded)
            _stateMachine.ChangeState(States.AirBourne);

        Owner.GetPlayerAnimator().SetFloat(ConstantStrings.RUN_PARAMETER, Owner.GetPlayerMovement().magnitude);
    }

    public void OnStateExit()
    {
        
    }
}
