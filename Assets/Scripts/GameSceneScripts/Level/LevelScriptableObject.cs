using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelScriptableObject", menuName = "ScriptableObject/LevelScriptableObject")]
public class LevelScriptableObject : ScriptableObject
{
    public List<Levels> LevelList;
}

[System.Serializable]
public struct Levels
{
    public LevelNumber LevelNumber;
    public List<TypesAndNumberOfEnemies> EnemyList;
}

[System.Serializable]
public struct TypesAndNumberOfEnemies
{
    public EnemyType EnemyType;
    public int NumberOfEnemiesOfThisType;
}

public enum LevelNumber
{
    Level_1,
}