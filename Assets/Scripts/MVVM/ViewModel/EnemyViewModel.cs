using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyViewModel : IEnemyViewModel
{
    private bool isDead;
    public event Action<float> OnHpChange;
    public IEnemyModel enemyModel { get; }

    public bool IsDead => isDead;

    public EnemyViewModel(IEnemyModel enemyModel)
    {
        this.enemyModel = enemyModel;
    }

    public void ApplyDamage(float damage)
    {
        enemyModel.CurrentHP -= damage;
        if(enemyModel.CurrentHP <= 0)
        {
            isDead = true;
            OnHpChange?.Invoke(enemyModel.CurrentHP);
        }

    }
}
