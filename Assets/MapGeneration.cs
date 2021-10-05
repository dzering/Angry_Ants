using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MapGeneration : MonoBehaviour
{
    public Transform floor;
    public static Vector3 BoundsField;

    private void Awake()
    {
        var col = floor.GetComponent<Collider>();
        BoundsField = GetBoundsField(col);
    }

    public Vector3 GetBoundsField(Collider col)
    {
        return new Vector3(col.bounds.max.x, 0, col.bounds.max.z);
    }


    //public static Vector3 GetRamdomPoint()
    //{
    //   int xRandom = (int)Random.Range(-bounds.x, bounds.x);
    //   int zRandom = (int)Random.Range(-bounds.y, bounds.y);

    //    return new Vector3(xRandom, 0, zRandom);

    //}

}
