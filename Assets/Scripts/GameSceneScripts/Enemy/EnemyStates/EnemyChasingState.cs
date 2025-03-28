using UnityEngine;

public class EnemyChasingState<T> : IState<T> where T : EnemyController
{
    public T Owner { get; set; }

    private readonly GenericStateMachine<T> _stateMachine;
    private Vector3 _destination;

    public EnemyChasingState(GenericStateMachine<T> stateMachine) => _stateMachine = stateMachine;

    public void OnStateEnter()
    {
        Owner.GetEnemyAnimator().SetFloat(ConstantStrings.SPEED_PARAMETER, Owner.GetEnemySO(Owner.GetEnemyType()).MoveSpeed);
    }

    public void Update()
    {
        MoveTowardsPlayer();

        if (!Owner.IsPlayerInDetectionZone)
            _stateMachine.ChangeState(States.Idle);

        if (ReachedPlayer())
            _stateMachine.ChangeState(States.Attack);
    }

    public void OnStateExit()
    {
        Owner.GetEnemyAnimator().SetFloat(ConstantStrings.SPEED_PARAMETER, 0);
    }

    private void MoveTowardsPlayer()
    {
        _destination = Owner.GetPlayerTransform().position;
        Owner.GetEnemyAgent().SetDestination(_destination);
    }

    private bool ReachedPlayer() => GetDistanceFromPlayer() <= Owner.GetEnemyAgent().stoppingDistance;

    private float GetDistanceFromPlayer() => Vector3.Distance(Owner.GetEnemyTransform().position, Owner.GetPlayerTransform().position);
}
