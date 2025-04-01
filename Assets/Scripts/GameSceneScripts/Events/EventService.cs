using System.Collections.Generic;
using UnityEngine;

public class EventService : GenericMonoSingleton<EventService>
{
    public EventController<LevelNumber> OnCurrentLevelSelectedEvent { get; private set; }
    public EventController<List<SpawnDataAndWaypoints>> OnSpawnDataInitialized { get; private set; }
    public EventController<int> OnDamageEvent { get; private set; }
    public EventController OnPlayerDeathEvent { get; private set; }
    public EventController OnEnemyDeathEvent { get; private set; }
    public EventController OnLevelWinEvent { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        InitializeEvents();
    }

    private void InitializeEvents()
    {
        OnCurrentLevelSelectedEvent = new EventController<LevelNumber>();
        OnSpawnDataInitialized = new EventController<List<SpawnDataAndWaypoints>>();
        OnDamageEvent = new EventController<int>();

        OnPlayerDeathEvent = new EventController();
        OnEnemyDeathEvent = new EventController();
        OnLevelWinEvent = new EventController();
    }
}
