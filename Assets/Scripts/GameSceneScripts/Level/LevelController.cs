using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private List<LevelScriptableObject> _levelSOList;
    private Dictionary<Level, int> _levelSODictionary;
    private Level _currentLevel;
    private int _numberOfEnemiesInThisLevel;

    private void OnEnable()
    {
        EventService.Instance.OnEnemyDeathEvent.AddListener(OnEnemyDeath);
    }

    public void Initialize(List<LevelScriptableObject> levelSOList)
    {
        _levelSOList = levelSOList;

        _levelSODictionary= new Dictionary<Level, int>();
        foreach(LevelScriptableObject levelSO in levelSOList)
            _levelSODictionary[levelSO.Level] = levelSO.NumberOfEnemies;

        _currentLevel = Level.Level_1;      //only one level as of now.
        _numberOfEnemiesInThisLevel = _levelSODictionary[_currentLevel];
    }

    private void OnEnemyDeath()
    {
        --_numberOfEnemiesInThisLevel;
        if (_numberOfEnemiesInThisLevel == 0)
            EventService.Instance.OnLevelWinEvent.InvokeEvent();
    }

    private void OnDisable()
    {
        EventService.Instance.OnEnemyDeathEvent.RemoveListener(OnEnemyDeath);
    }
}
