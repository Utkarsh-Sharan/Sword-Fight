using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObject/EnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public float MoveSpeed;
    public float AttackTime;
    public float ChaseDelay;
    public float IdleTime;
}
