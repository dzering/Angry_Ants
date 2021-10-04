using UnityEngine;
internal sealed class SpiderFactory : EnemyFactory
{

    public override EnemyBase CreateInsection()
    {
        var item = Resources.Load<EnemyView>("Insections/Spider");
        var spider = GameObject.Instantiate(item);

        spider.Initialize(new EnemyViewModel(new EnemyModel(10)));


        return spider;
    }
}