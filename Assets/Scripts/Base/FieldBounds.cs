using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FieldBounds 
{
    static Vector3 bounds;
    readonly Transform gameField;

    public FieldBounds(Transform gameField)
    {
        this.gameField = gameField;
    }

    static void GetBounds()
    {

    }
}
