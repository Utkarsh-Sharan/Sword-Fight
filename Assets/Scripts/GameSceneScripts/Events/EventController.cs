using System;

public class EventController<T>
{
    public Func<T> BaseEvent;
    public void AddListener(Func<T> listener) => BaseEvent += listener;
    public T InvokeEvent() => BaseEvent.Invoke();
    public void RemoveListener(Func<T> listener) => BaseEvent -= listener;
}

public class EventController
{
    public Action BaseEvent;
    public void AddListener(Action listener) => BaseEvent += listener;
    public void InvokeEvent() => BaseEvent?.Invoke();
    public void RemoveListener(Action listener) => BaseEvent -= listener;
}
