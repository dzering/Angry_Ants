using System;
using System.Collections.Generic;

public interface ISubject
{
    void Subscribe(State eventType, IObserver listener);
    void Unsubscribe(State eventType, IObserver listener);

    void Notify(State eventType);
}
