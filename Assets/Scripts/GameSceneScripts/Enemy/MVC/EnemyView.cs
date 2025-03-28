using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyView : MonoBehaviour, IDamageable
{
    [SerializeField] protected EnemyType enemyType;
    [SerializeField] protected List<Transform> waypointTransformList;

    [SerializeField] protected NavMeshAgent enemyAgent;
    [SerializeField] protected Animator enemyAnimator;
    [SerializeField] protected DamageApplier damageApplier;

    [SerializeField] protected VisualEffect footStepVFX;
    [SerializeField] protected VisualEffect attackVFX;

    protected Dictionary<EnemyType, EnemyScriptableObject> enemySODictionary = new Dictionary<EnemyType, EnemyScriptableObject>();

    public void Initialize(Dictionary<EnemyType, EnemyScriptableObject> enemySODictionary)
    {
        this.enemySODictionary = enemySODictionary;
    }

    public virtual void OnDamage(int damageAmount) { }

    public EnemyScriptableObject GetEnemySO(EnemyType enemyType) => enemySODictionary[enemyType];
    public EnemyType GetEnemyType() => enemyType;
}
