using UnityEngine;
using Cinemachine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObject/PlayerScriptableObject")]
public class PlayerScriptableObject : ScriptableObject
{
    public PlayerView PlayerView;
    public Vector3 SpawnPosition;
    public Vector3 SpawnRotation;
    public PlayerFollowVCamStats VCamStats;
    public int MaxHealth;
    public int AttackDamage;
    public float MoveSpeed;
    public float Gravity;
    public float TurnSmoothTime;
}

[System.Serializable]
public struct PlayerFollowVCamStats
{
    public CinemachineVirtualCamera VirtualCamera;
    public Vector3 VCamPosition;
    public Quaternion VCamRotation;
}