using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected EnemyType enemyType;
    [SerializeField] protected List<Transform> waypointTransformList;
    [SerializeField] protected DamageApplier damageApplier;

    protected Dictionary<EnemyType, EnemyScriptableObject> enemySODictionary;
    protected NavMeshAgent enemyAgent;
    protected Animator enemyAnimator;

    protected Transform playerTransform;
    protected PlayerScriptableObject playerSO;

    private bool _isPlayerDead;
    public bool IsPlayerInDetectionZone { get; set; }

    public virtual void Initialize(NavMeshAgent enemyAgent, Animator enemyAnimator, List<EnemyScriptableObject> enemySOList)
    {
        _isPlayerDead = false;
        this.enemyAgent = enemyAgent;
        this.enemyAnimator = enemyAnimator;
        damageApplier.enabled = false;

        enemySODictionary = new Dictionary<EnemyType, EnemyScriptableObject>();
        foreach (EnemyScriptableObject enemySO in enemySOList)
            enemySODictionary[enemySO.EnemyType] = enemySO;

        EventService.Instance.OnPlayerDeathEvent.AddListener(OnPlayerDead);
    }

    public void Dependency(PlayerService playerService)
    {
        playerTransform = playerService.GetPlayerTransform();
        playerSO = playerService.GetPlayerSO();
    }

    //public void OnDamage()
    //{
    //    int damageAmount = playerSO.AttackDamage;

    //    if (_currentHealth > 0)
    //        _currentHealth -= damageAmount;
    //    else
    //        EnemyDead();
    //}

    #region Animation Events
    public void EnemyAttackStart() => damageApplier.enabled = true;
    public void EnemyAttackEnd() => damageApplier.enabled = false;
    #endregion

    private void OnPlayerDead() => _isPlayerDead = true;

    #region Getters
    public Animator GetEnemyAnimator() => enemyAnimator;
    public NavMeshAgent GetEnemyAgent() => enemyAgent;
    public List<Transform> GetWayPointTransformList() => waypointTransformList;
    public EnemyScriptableObject GetEnemySO(EnemyType enemyType) => enemySODictionary[enemyType];
    public EnemyType GetEnemyType() => enemyType;
    public Transform GetPlayerTransform() => playerTransform;
    public bool IsPlayerDead() => _isPlayerDead;
    #endregion

    protected void OnDestroy()
    {
        EventService.Instance.OnPlayerDeathEvent.RemoveListener(OnPlayerDead);
    }
}
