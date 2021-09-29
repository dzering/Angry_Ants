using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyView 
{
    event EventHandler<EnemyClickedEventArgs> OnClicked;
    Vector3 Position { set; }
}
