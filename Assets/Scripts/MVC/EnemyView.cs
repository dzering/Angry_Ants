using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    private IEnemyViewModel enemyViewModel;
    private IEnemyAI enemyAI;
    EventManager e;

    public void Initialize(IEnemyViewModel enemyViewModel)
    {
        this.enemyViewModel = enemyViewModel;
        enemyViewModel.OnHpChange += GetDamage;
        enemyAI = new EnemyAI(transform, GetComponent<NavMeshAgent>());
        e = new EventManager();
    }

    
    public void GetDamage(float damage)
    {

        enemyViewModel.ApplyDamage(damage);
    }


}
