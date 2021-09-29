using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : ISubject
{
    public Dictionary<State, List<IObserver>> Listeners;
    public EventManager()
    {
        Listeners = new Dictionary<State, List<IObserver>>();
    }

    public void Subscribe(State eventType, IObserver listener)
    {
        if (!Listeners.ContainsKey(eventType))
        {
            Listeners.Add(eventType, new List<IObserver>());
            if(Listeners.TryGetValue(eventType, out List<IObserver> value))
            {
                value.Add(listener);
            }
        }
        else
        {
            Listeners.TryGetValue(eventType, out List<IObserver> value);
            value.Add(listener);
        }
        
    }

    public void Unsubscribe(State eventType, IObserver listener)
    {
        Listeners.TryGetValue(eventType, out List<IObserver> value);
        value.Remove(listener);
    }

    public void Notify(State eventType)
    {
        Listeners.TryGetValue(eventType, out List<IObserver> listeners);
        if(listeners != null) foreach (var listener in listeners) listener.ChangeState();
        //foreach (var listener in listeners)
        //{
        //    listener.ChangeState();
        //}
    }
}
