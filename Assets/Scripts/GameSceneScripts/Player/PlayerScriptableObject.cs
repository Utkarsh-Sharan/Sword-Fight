using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObject/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
    public int MaxHealth;
    public int AttackDamage;
    public float MoveSpeed;
    public float Gravity;
    public float TurnSmoothTime;
}
