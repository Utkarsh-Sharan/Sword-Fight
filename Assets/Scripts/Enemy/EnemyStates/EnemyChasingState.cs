using UnityEngine;

public class EnemyChasingState<T> : IState<T> where T : EnemyController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;
    private Vector3 _destination;

    public EnemyChasingState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        
    }

    public void Update()
    {
        MoveTowardsPlayer();
        if (ReachedPlayer())
            _stateMachine.ChangeState(States.Attack);
    }

    public void OnStateExit()
    {
        
    }

    private void MoveTowardsPlayer()
    {
        _destination = Owner.GetPlayerPosition();
        Owner.GetEnemyAgent().SetDestination(_destination);
    }

    private bool ReachedPlayer() => Owner.GetEnemyAgent().remainingDistance <= Owner.GetEnemyAgent().stoppingDistance;
}
