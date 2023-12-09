using UnityEngine;

namespace Course_Library.Scripts
{
    public abstract class Boost : MonoBehaviour
    {
        public BoostType type;
    }

    public class PowerUp : Boost
    {
        public float strength;

        public void Interact(Rigidbody enemyRb)
        {
            Vector3 direction = enemyRb.gameObject.transform.position - transform.position;
            enemyRb.AddForce(direction.normalized * strength, ForceMode.Impulse);
        }
    }
}