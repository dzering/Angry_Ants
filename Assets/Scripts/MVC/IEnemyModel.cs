using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyModel
{
    event EventHandler<EnemyPositionChangedEventArgs> OnChangePosition;
    Vector3 Position { get; set; }


}
