using System.Collections.Generic;

public class GenericStateMachine<T> where T : class
{
    protected T owner;
    protected IState<T> currentState;
    protected Dictionary<States, IState<T>> states = new Dictionary<States, IState<T>>();

    public GenericStateMachine(T owner) => this.owner = owner;

    public void Update() => currentState?.Update();

    public void ChangeState(States newState) => ChangeState(states[newState]);

    protected void ChangeState(IState<T> newState)
    {
        currentState?.OnStateExit();
        currentState = newState;
        currentState.OnStateEnter();
    }

    protected void SetOwner()
    {
        foreach (IState<T> state in states.Values)
        {
            state.Owner = owner;
        }
    }
}
