using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class AntCreator : EnemyFactory
{
    public override EnemyBase CreateInsection()
    {
        var ant = Object.Instantiate(Resources.Load<EnemyBase>("Insections/Ant"));
        return ant;
    }

}
