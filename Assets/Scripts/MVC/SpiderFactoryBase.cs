using UnityEngine;
public class SpiderFactoryBase
{

    public EnemyView CreateSpider_()
    {
        var item = Resources.Load<EnemyView>("Insections/Spider");
        var spider = GameObject.Instantiate(item);

        spider.Initialize(new EnemyViewModel(new EnemyModel(10)));


        return spider;
    }
}