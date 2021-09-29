using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : IEnemyController
{
    private readonly EnemyView View;
    private readonly EnemyModel Model;

    public EnemyController(EnemyView view, EnemyModel spider)
    {
        View = view;
        Model = spider;

        View.OnClicked += HandleClicked;
        Model.OnChangePosition += HandlePositionChanged;
    }

    private void HandleClicked(object sender, EnemyClickedEventArgs e)
    {
        Model.position += new Vector3(1, 0, 0);
    }

    private void HandlePositionChanged(object sender, EnemyPositionChangedEventArgs e)
    {
        SyncPosition();
    }

    private void SyncPosition()
    {
        View.Position = Model.Position;
    }
}


public class SpiderFactory
{
    public EnemyModel CreateSpider()
    {
        var item = Resources.Load<GameObject>("Insections/Spider");
        var spider = Object.Instantiate(item);
        var navMesh = spider.GetComponent<NavMeshAgent>();
        Transform t = spider.transform;
        EnemyAI enemyAI = new EnemyAI(t, navMesh);

        EventManager e = new EventManager();
        EnemyModel s = new EnemyModel(e, enemyAI);
        EnemyController ec = new EnemyController(spider.GetComponent<EnemyView>(), s);

        return s;
    }
}