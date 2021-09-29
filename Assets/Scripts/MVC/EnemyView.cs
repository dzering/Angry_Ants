using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyView : MonoBehaviour, IEnemyView
{
    NavMeshAgent NavMeshAgent;
    Transform TransformPosition;

    public Vector3 Position { set => transform.position = value; }

    public event EventHandler<EnemyClickedEventArgs> OnClicked = (sender, e) =>{};

    private void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        TransformPosition = transform;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Action();
        }
    }

    void Action()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, Mathf.Infinity) && hit.transform == transform)
        {
            var eventArg = new EnemyClickedEventArgs();
            OnClicked(this, eventArg);
        }
    }

}
