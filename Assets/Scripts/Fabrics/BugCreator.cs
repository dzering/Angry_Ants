using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class BugCreator : InsectionCreator
{
    public override EnemyBase CreateInsection()
    {
        var bug = Object.Instantiate(Resources.Load<Bug>("Insections/Bug"));
        return bug;
    }
}
