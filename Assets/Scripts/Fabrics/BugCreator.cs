using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class BugCreator : InsectionCreator
{
    public override InsectionBase CreateInsection()
    {
        var bug = Object.Instantiate(Resources.Load<Bug>("Insections/Bug"));
        return bug;
    }
}
