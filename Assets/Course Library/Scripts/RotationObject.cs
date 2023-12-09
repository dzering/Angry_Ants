using UnityEngine;

namespace Course_Library.Scripts
{
    public class RotationObject : MonoBehaviour
    {
        public float angleSpeed = 10f;

        void Update()
        {
            transform.Rotate(Vector3.up, Time.deltaTime * angleSpeed);
        }
    }
}
