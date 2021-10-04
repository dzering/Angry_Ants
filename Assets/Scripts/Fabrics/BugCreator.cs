using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class BugCreator : EnemyFactory
{
    public override EnemyBase CreateInsection()
    {
        var bug = Object.Instantiate(Resources.Load<EnemyBase>("Insections/Bug"));
        return bug;
    }
}
