using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyView : MonoBehaviour, IDamageable
{
    [SerializeField] protected EnemyType enemyType;
    [SerializeField] protected List<Transform> waypointTransformList;

    [SerializeField] protected Animator enemyAnimator;
    [SerializeField] protected NavMeshAgent enemyAgent;
    [SerializeField] protected DamageApplier damageApplier;

    [SerializeField] protected VisualEffect footStepVFX;
    [SerializeField] protected VisualEffect attackVFX;

    public virtual void OnDamage(int damageAmount) { }

    public Animator GetEnemyAnimator() => this.enemyAnimator;
    public NavMeshAgent GetEnemyAgent() => this.enemyAgent;
    public List<Transform> GetWayPointTransformList() => this.waypointTransformList;
}
