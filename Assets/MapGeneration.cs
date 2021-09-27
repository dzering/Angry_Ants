using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class MapGeneration : MonoBehaviour
{
    public Transform floor;
    static Vector3 bounds;

    private void Start()
    {
        var col = floor.GetComponent<Collider>();
        bounds = GetBoundsField(col);
        Debug.Log("");
    }

    static Vector3 GetBoundsField(Collider col)
    {
        bounds = new Vector3(col.bounds.max.x, 0, col.bounds.max.z);
        return bounds;
    }

    public static Vector3 GetRamdomPoint()
    {
       int xRandom = (int)Random.Range(-bounds.x, bounds.x);
       int zRandom = (int)Random.Range(-bounds.y, bounds.y);

        return new Vector3(xRandom, 0, zRandom);

    }

    public static Vector3 GetBounds()
    {
        return new Vector3(bounds.x, 0, bounds.y);
    }
}
