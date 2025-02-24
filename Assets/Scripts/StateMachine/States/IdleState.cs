using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState<T> : IState<T> where T : class
{
    public T Owner { get; set; }
    private GenericStateMachine<T> _stateMachine;

    public IdleState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {

    }

    public void Update()
    {

    }

    public void OnStateExit()
    {

    }
}
