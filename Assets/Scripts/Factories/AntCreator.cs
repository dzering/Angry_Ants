using Base;
using UnityEngine;

namespace Factories
{
    internal class AntCreator : EnemyFactory
    {
        public override EnemyBase CreateInsection()
        {
            return Object.Instantiate(Resources.Load<EnemyBase>("Insections/Ant"));
        }

    }
}
