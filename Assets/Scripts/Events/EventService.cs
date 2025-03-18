public class EventService
{
    public EventController OnPlayerDeathEvent { get; private set; }

    public EventService()
    {
        OnPlayerDeathEvent = new EventController();
    }
}
