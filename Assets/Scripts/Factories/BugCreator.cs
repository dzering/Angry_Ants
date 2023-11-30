using Base;
using UnityEngine;

namespace Factories
{
    internal class BugCreator : EnemyFactory
    {
        public override EnemyBase CreateInsection()
        {
            var bug = Object.Instantiate(Resources.Load<EnemyBase>("Insections/Bug"));
            return bug;
        }
    }
}
