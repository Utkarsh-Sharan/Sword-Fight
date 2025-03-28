public class PlayerAttackState<T> : IState<T> where T : PlayerController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;

    public PlayerAttackState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Owner.GetPlayerAnimator().SetTrigger(ConstantStrings.ATTACK_PARAMETER);
    }

    public void Update()
    {
        _stateMachine.ChangeState(States.Idle);
    }

    public void OnStateExit()
    {
        
    }
}
