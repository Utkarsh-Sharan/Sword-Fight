using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private Dictionary<LevelNumber, Levels> _levelDictionary;
    private LevelNumber _currentLevel;
    private int _totalEnemiesInThisLevel = 0;

    private void OnEnable()
    {
        EventService.Instance.OnEnemyDeathEvent.AddListener(OnEnemyDeath);
    }

    public void Initialize(LevelScriptableObject levelSO)
    {
        _levelDictionary = new Dictionary<LevelNumber, Levels>();

        foreach (Levels level in levelSO.LevelList)
            _levelDictionary[level.LevelNumber] = level;

        _currentLevel = LevelNumber.Level_1;
        CalculateTotalEnemiesInThisLevel();
    }

    private void CalculateTotalEnemiesInThisLevel()
    {
        Levels levelData = _levelDictionary[_currentLevel];

        foreach (TypesAndNumberOfEnemies enemyData in levelData.EnemyList)
            _totalEnemiesInThisLevel += enemyData.NumberOfEnemies;
    }

    private void OnEnemyDeath()
    {
        --_totalEnemiesInThisLevel;
        if (_totalEnemiesInThisLevel == 0)
            EventService.Instance.OnLevelWinEvent.InvokeEvent();
    }

    private void OnDisable()
    {
        EventService.Instance.OnEnemyDeathEvent.RemoveListener(OnEnemyDeath);
    }
}
