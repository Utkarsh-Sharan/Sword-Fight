public class PlayerAirBourneState<T> : IState<T> where T : PlayerController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;

    public PlayerAirBourneState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Owner.GetPlayerAnimator().SetBool(ConstantStrings.AIRBOURNE_PARAMETER, !Owner.GetCharacterController().isGrounded);
    }

    public void Update()
    {
        if (Owner.GetCharacterController().isGrounded)
            _stateMachine.ChangeState(States.Idle);
    }

    public void OnStateExit()
    {
        Owner.GetPlayerAnimator().SetBool(ConstantStrings.AIRBOURNE_PARAMETER, false);
    }
}
