using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnDataScriptableObject", menuName = "ScriptableObject/EnemySpawnDataScriptableObject")]
public class EnemySpawnDataScriptableObject : ScriptableObject
{
    public List<LevelSpawnData> LevelSpawnData;
}

[System.Serializable]
public struct LevelSpawnData
{
    public LevelNumber LevelNumber;
    public List<SpawnDataAndWaypoints> SpawnDataAndWaypoints;
}

[System.Serializable]
public struct SpawnDataAndWaypoints
{
    public EnemyType EnemyType;
    public Vector3 SpawnPosition;
    public List<Vector3> Waypoints;
}