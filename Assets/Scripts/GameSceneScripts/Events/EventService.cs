using System.Collections.Generic;
using UnityEngine;

public class EventService : GenericMonoSingleton<EventService>
{
    public EventController<Transform> OnGetPlayerTransformEvent { get; private set; }
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
        OnDamageEvent = new EventController<int>();
        OnGetPlayerTransformEvent = new EventController<Transform>();
        OnCurrentLevelSelectedEvent = new EventController<LevelNumber>();
        OnSpawnDataInitialized = new EventController<List<SpawnDataAndWaypoints>>();

        OnPlayerDeathEvent = new EventController();
        OnEnemyDeathEvent = new EventController();
        OnLevelWinEvent = new EventController();
    }
}
