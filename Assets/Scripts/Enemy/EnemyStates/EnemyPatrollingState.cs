using UnityEngine;

public class EnemyPatrollingState<T> : IState<T> where T : EnemyController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;
    private int _currentPatrollingIndex = -1;
    private Vector3 _destination;

    public EnemyPatrollingState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        SetNextWayPointIndex();
        _destination = GetDestination();
        MoveTowardsDestination(_destination);
    }

    public void Update()
    {
        if (ReachedDestination())
            _stateMachine.ChangeState(States.Idle);
        //Will do later: if player detected, start chasing.
    }

    public void OnStateExit() { }

    private void SetNextWayPointIndex()
    {
        if (_currentPatrollingIndex == Owner.GetWayPointTransformList().Count - 1)
            _currentPatrollingIndex = 0;
        else
            ++_currentPatrollingIndex;
    }

    private Vector3 GetDestination() => Owner.GetWayPointTransformList()[_currentPatrollingIndex].position;

    private void MoveTowardsDestination(Vector3 destination)
    {
        Owner.GetEnemyAgent().isStopped = false;
        Owner.GetEnemyAgent().SetDestination(destination);
        Owner.GetEnemyAnimator().SetFloat(ConstantStrings.RUN_PARAMETER, 2);
    }

    private bool ReachedDestination() => Owner.GetEnemyAgent().remainingDistance <= Owner.GetEnemyAgent().stoppingDistance;
}
