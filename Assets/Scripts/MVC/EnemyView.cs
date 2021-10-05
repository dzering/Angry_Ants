using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : EnemyBase
{
    private IEnemyViewModel enemyViewModel;
    private IEnemyAI enemyAI;

    public void Initialize(IEnemyViewModel enemyViewModel)
    {
        this.enemyViewModel = enemyViewModel;
        enemyViewModel.OnHpChange += Death;
        enemyAI = new EnemyAI(transform, GetComponent<NavMeshAgent>());
        events = new EventManager();
    }

    
    public void GetDamage(float damage)
    {
        enemyViewModel.ApplyDamage(damage);
    }

    public override void Death(float damage)
    {
        events.Notify(State.Dead);
        gameObject.SetActive(!enemyViewModel.IsDead);
    }


}
