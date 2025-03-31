using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private Dictionary<LevelNumber, Levels> _levelDictionary;
    private LevelNumber _currentLevel;
    private Levels _levelData;
    private int _totalEnemiesInThisLevel = 0;

    private void OnEnable()
    {
        EventService.Instance.OnEnemyDeathEvent.AddListener(OnEnemyDeath);
        EventService.Instance.OnCurrentLevelSelectedEvent.AddListener(OnCurrentLevelSelected);
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
        _levelData = _levelDictionary[_currentLevel];

        foreach (TypesAndNumberOfEnemies enemyData in _levelData.EnemyList)
            _totalEnemiesInThisLevel += enemyData.NumberOfEnemies;
    }

    private LevelNumber OnCurrentLevelSelected() => _currentLevel;

    private void OnEnemyDeath()
    {
        --_totalEnemiesInThisLevel;
        if (_totalEnemiesInThisLevel == 0)
            EventService.Instance.OnLevelWinEvent.InvokeEvent();
    }

    private void OnDisable()
    {
        EventService.Instance.OnEnemyDeathEvent.RemoveListener(OnEnemyDeath);
        EventService.Instance.OnCurrentLevelSelectedEvent.RemoveListener(OnCurrentLevelSelected);
    }
}
