using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObject/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
    public PlayerView PlayerView;
    public Vector3 SpawnPosition;
    public Vector3 SpawnRotation;
    public int MaxHealth;
    public int AttackDamage;
    public float MoveSpeed;
    public float Gravity;
    public float TurnSmoothTime;
}
