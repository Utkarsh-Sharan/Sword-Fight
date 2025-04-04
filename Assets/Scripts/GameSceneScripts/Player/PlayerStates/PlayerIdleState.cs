using UnityEngine;

public class PlayerIdleState<T> : IState<T> where T : PlayerController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;

    public PlayerIdleState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        
    }

    public void Update()
    {
        if (Owner.GetPlayerMovement().magnitude > 0f)
            _stateMachine.ChangeState(States.Running);
        if (Input.GetMouseButtonDown(0))
            _stateMachine.ChangeState(States.Attack);
    }

    public void OnStateExit()
    {
        
    }
}
