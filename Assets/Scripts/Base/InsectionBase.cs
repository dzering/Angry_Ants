using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class InsectionBase : MonoBehaviour
{
    public EventManager events;

    private void Awake()
    {
        events = new EventManager();
    }
 
    public void Dies()
    {
        events.Notify(State.Dead);
        Destroy(gameObject);
    }
}
