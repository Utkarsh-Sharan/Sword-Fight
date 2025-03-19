public class EventService
{
    public EventController OnPlayerDeathEvent { get; private set; }
    public EventController OnEnemyDeathEvent { get; private set; }
    public EventController OnLevelWinEvent { get; private set; }

    public EventService()
    {
        OnPlayerDeathEvent = new EventController();
        OnEnemyDeathEvent = new EventController();
        OnLevelWinEvent = new EventController();
    }
}
