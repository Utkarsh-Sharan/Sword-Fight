using System;

public class EventController
{
    public Action BaseEvent;
    public void AddListener(Action listener) => BaseEvent += listener;
    public void InvokeEvent() => BaseEvent?.Invoke();
    public void RemoveListener(Action listener) => BaseEvent -= listener;
}
