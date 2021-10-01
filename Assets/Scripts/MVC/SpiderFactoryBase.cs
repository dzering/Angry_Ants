using UnityEngine;
public class SpiderFactoryBase
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
        EnemyViewModel ec = new EnemyViewModel(spider.GetComponent<EnemyView>(), s);

        return s;
    }
}