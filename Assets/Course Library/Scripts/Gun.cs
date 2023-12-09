using UnityEngine;

namespace Course_Library.Scripts
{
    public class Gun : MonoBehaviour
    {
        public GameObject _prefabProjectile;
        private Transform _gunPosition;
        public float speed = 10f;
        private float _reloadTime = 1.5f;
        private float currentTime = 0;


        private void Update()
        {
            if (CanFire())
                Fire();
        }

        private void Fire()
        {
            GameObject projectile = Instantiate(_prefabProjectile, transform.position, transform.rotation * Quaternion.Euler(90,0,0));
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            projectileRb.AddForce(transform.forward * speed, ForceMode.Impulse);
            currentTime = _reloadTime;
        }

        private bool CanFire()
        {
            if (currentTime <= 0)
                return true;
            currentTime -= Time.deltaTime;
            return false;
        }
    }
}
