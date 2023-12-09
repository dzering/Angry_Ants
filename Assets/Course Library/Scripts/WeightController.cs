using UnityEngine;
using Random = UnityEngine.Random;

namespace Course_Library.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class WeightController : MonoBehaviour
    {
        private Rigidbody _rb;
        private float maxMass = 3;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();

            float rbMass = GetRandom(); 
            _rb.mass = rbMass;
            Vector3 localScale = transform.localScale;
            transform.localScale = localScale * (1 + rbMass / 10);
        }

        private float GetRandom()
        {
            return Random.Range(1, maxMass);
        }
    }
}
