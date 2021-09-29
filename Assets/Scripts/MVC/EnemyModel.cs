using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyModel : IEnemyModel
{
    public Vector3 position;
    public Vector3 Position { get { return position; } set {if(position != value) position = value; var eventArgs = new EnemyPositionChangedEventArgs();
            OnChangePosition(this, eventArgs);
        } }

    public event EventHandler<EnemyPositionChangedEventArgs> OnChangePosition = (sender, e) => { };

    public EventManager Events;
        IEnemyAI enemyAI;

        public EnemyModel(EventManager eventManager, IEnemyAI enemyAI)
    {
        Events = eventManager;
        this.enemyAI = enemyAI;
    }



    public void Dies()
        {
            Events.Notify(State.Dead);
        }
}
