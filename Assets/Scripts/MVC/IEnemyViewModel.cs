using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyViewModel
{
    IEnemyModel enemyModel { get; }
    bool IsDead { get; }
    void ApplyDamage(float damage);
    event Action<float> OnHpChange;
}
