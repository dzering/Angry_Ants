using UnityEngine;

namespace _Root._Scripts
{
    public class Death : MonoBehaviour
    {
        public GameObject deathVFX;
        private void OnMouseDown()
        {
            if(gameObject.CompareTag("Enemy"))
            {
                Instantiate(deathVFX, transform.position, deathVFX.transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
