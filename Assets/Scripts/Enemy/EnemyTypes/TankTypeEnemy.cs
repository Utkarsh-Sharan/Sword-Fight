using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TankTypeEnemy : EnemyController
{
    private float _moveSpeed = 2.3f;

    public override void Initialize(NavMeshAgent enemyAgent, Animator enemyAnimator)
    {
        base.Initialize(enemyAgent, enemyAnimator);
        this.enemyAgent.speed = _moveSpeed;
    }

}
