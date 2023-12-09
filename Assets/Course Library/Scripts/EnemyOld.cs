using UnityEngine;

namespace Course_Library.Scripts
{
    public class EnemyOld : MonoBehaviour
    {
        public float speed;
        private Rigidbody _rb;
        private Transform _player;

        // Start is called before the first frame update
        void Start()
        {
            _player = GameObject.Find("Player").transform;
            _rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 lookDirection = (_player.position - transform.position).normalized;
            _rb.AddForce(lookDirection * speed);

            if (transform.position.y < -5f)
                Destroy(gameObject);
        }
    }
}
