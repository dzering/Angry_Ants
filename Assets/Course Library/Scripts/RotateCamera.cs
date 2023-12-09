using UnityEngine;

namespace Course_Library.Scripts
{
    public class RotateCamera : MonoBehaviour
    {
        public float angleSpeed = 50;
        public float forcedAngleSpeed = 100;
        private float _speed;

        // Start is called before the first frame update
        void Start()
        {
            _speed = angleSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            _speed = angleSpeed;
            if (Input.GetKey(KeyCode.LeftShift))
                _speed = forcedAngleSpeed;
            
            float inputValue = -Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, _speed * Time.deltaTime * inputValue);
        }
    }
}
