using System;
using UnityEngine;

namespace _Root._Scripts
{
    public class Target : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Enemy"))
                Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
