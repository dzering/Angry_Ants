using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyModel : IEnemyModel
{
    public float MaxHP { get; }
    public float CurrentHP { get; set; } 
    public EnemyModel(float maxHP)
    {
        MaxHP = maxHP;
        CurrentHP = MaxHP;
    }
}
