using UnityEngine;

public class Sun : MonoBehaviour
{
    public int angleSpeed = 2;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Time.deltaTime *angleSpeed, 0, Space.Self);
    }
}
