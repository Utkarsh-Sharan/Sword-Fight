using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/EnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public EnemyType EnemyType;
    public EnemyView EnemyView;
    public Vector3 SpawnPosition;
    public Vector3 SpawnRotation;
    public float MoveSpeed;
    public float AttackTime;
    public float ChaseDelay;
    public float IdleTime;
    public int MaxHealth;
    public int AttackDamage;
}