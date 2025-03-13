using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent _enemyAgent;
    private Animator _enemyAnimator;
    private Transform _playerTransform;
    private float _moveSpeed = 2f;

    private EnemyStateMachine _stateMachine;
    [SerializeField] private List<Transform> _waypointTransformList;
    [SerializeField] private BoxCollider _playerDetectionCollider;

    public void Initialze(NavMeshAgent enemyAgent, Animator enemyAnimator)
    {
        _enemyAgent = enemyAgent;
        _enemyAnimator = enemyAnimator;

        _enemyAgent.speed = _moveSpeed;
        _stateMachine = new EnemyStateMachine(this);
        _stateMachine.ChangeState(States.Idle);
    }

    public void Dependency(PlayerService playerService)
    {
        _playerTransform = playerService.GetPlayerTransform();
    }

    //private void FixedUpdate()
    //{
    //    CalculateMovement();
    //}

    private void Update()
    {
        _stateMachine.Update();
    }

    //private void CalculateMovement()
    //{
    //    if(Vector3.Distance(this.transform.position, _playerTransform.position) >= _enemyAgent.stoppingDistance)
    //    {
    //        _enemyAgent.SetDestination(_playerTransform.position);
    //        _enemyAnimator.SetFloat(ConstantStrings.RUN_PARAMETER, _moveSpeed);
    //    }
    //    else
    //    {
    //        _enemyAgent.SetDestination(this.transform.position);
    //        _enemyAnimator.SetFloat(ConstantStrings.RUN_PARAMETER, 0);
    //    }
    //}

    public Animator GetEnemyAnimator() => _enemyAnimator;
    public NavMeshAgent GetEnemyAgent() => _enemyAgent;
    public List<Transform> GetWayPointTransformList() => _waypointTransformList;
}
