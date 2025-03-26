using UnityEngine;

public class EventService : MonoBehaviour
{
    public static EventService Instance { get; private set; }

    public EventController<int> OnDamageEvent { get; private set; }
    public EventController OnPlayerDeathEvent { get; private set; }
    public EventController OnEnemyDeathEvent { get; private set; }
    public EventController OnLevelWinEvent { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        InitializeEvents();
    }

    private void InitializeEvents()
    {
        OnDamageEvent = new EventController<int>();

        OnPlayerDeathEvent = new EventController();
        OnEnemyDeathEvent = new EventController();
        OnLevelWinEvent = new EventController();
    }
}
