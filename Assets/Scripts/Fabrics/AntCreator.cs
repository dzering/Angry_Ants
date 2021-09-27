using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class AntCreator : InsectionCreator
{
    public override InsectionBase CreateInsection()
    {
        var ant = Object.Instantiate(Resources.Load<Ant>("Insections/Ant"));
        return ant;
    }

}
