using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState<T> : IState<T> where T : class
{
    public T Owner { get; set; }

    private GenericStateMachine<T> _stateMachine;
    private float _movementMagnitude;

    public IdleState(GenericStateMachine<T> stateMachine, float movementMagnitude)
    {
        _stateMachine = stateMachine;
        _movementMagnitude = movementMagnitude;
    }

    public void OnStateEnter()
    {

    }

    public void Update()
    {
        if(_movementMagnitude > 0f)
            _stateMachine.ChangeState(States.Running);
    }

    public void OnStateExit()
    {

    }
}
