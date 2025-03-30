using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private LevelScriptableObject _levelSO;
    private Dictionary<Levels, int> _levelSODictionary;
    private LevelNumber _currentLevel;
    private int _totalEnemiesInThisLevel;

    private void OnEnable()
    {
        EventService.Instance.OnEnemyDeathEvent.AddListener(OnEnemyDeath);
    }

    public void Initialize(LevelScriptableObject levelSO)
    {
        _levelSO = levelSO;
        _levelSODictionary = new Dictionary<Levels, int>();
        //foreach (Levels level in _levelSO)
        //    _levelSODictionary[levelSO.Level] = levelSO.NumberOfEnemies;

        //_currentLevel = _levelSO.LevelList;
        
        CalculateTotalEnemiesInThisLevel(_currentLevel);
    }

    private void CalculateTotalEnemiesInThisLevel(LevelNumber currentLevel)
    {
        //foreach (int numberOfEnemiesOfThisType in currentLevel)
        //{
        //    _totalEnemiesInThisLevel += numberOfEnemiesOfThisType;
        //}
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
