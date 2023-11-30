using Base;
using MVVM.Model;
using MVVM.View;
using MVVM.ViewModel;
using UnityEngine;

namespace Factories
{
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
}