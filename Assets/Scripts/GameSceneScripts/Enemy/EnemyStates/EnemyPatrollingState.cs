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
        Owner.GetEnemyAnimator().SetFloat(ConstantStrings.SPEED_PARAMETER, Owner.GetEnemySO(Owner.GetEnemyType()).MoveSpeed);
    }

    public void Update()
    {
        if (ReachedDestination())
            _stateMachine.ChangeState(States.Idle); 
        
        if (Owner.IsPlayerInDetectionZone)
            _stateMachine.ChangeState(States.Chasing);
    }

    public void OnStateExit() { }

    private void SetNextWayPointIndex()
    {
        if (_currentPatrollingIndex == Owner.GetWaypointsList().Count - 1)
            _currentPatrollingIndex = 0;
        else
            ++_currentPatrollingIndex;
    }

    private Vector3 GetDestination() => Owner.GetWaypointsList()[_currentPatrollingIndex];

    private void MoveTowardsDestination(Vector3 destination) => Owner.GetEnemyAgent().SetDestination(destination);

    private bool ReachedDestination() => Owner.GetEnemyAgent().remainingDistance <= Owner.GetEnemyAgent().stoppingDistance;
}
