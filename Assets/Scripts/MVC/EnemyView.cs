using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour
{
    private IEnemyViewModel enemyViewModel;

    public void Initialize(IEnemyViewModel enemyViewModel)
    {
        this.enemyViewModel = enemyViewModel;
       // enemyViewModel.OnHpChange += DoThomthing;
    }
    
    void Action()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, Mathf.Infinity))
            {
               if(hit.collider.TryGetComponent<EnemyView>)
            }
        }

    }

}
