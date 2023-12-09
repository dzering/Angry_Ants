using System;
using System.Collections;
using UnityEngine;


namespace Course_Library.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        public Boost currentBoost;


        public GameObject indicatorPowerUp;
        public GameObject gunPowerUp;
        public float speed = 5F;
        private GameObject _focalPoint;
        public bool hasPowerUp;
        public float powerUpStrength;
        private const int SECONDS = 7;
        private Rigidbody _playerRb;
        public bool hasGun;

        private void Start()
        {
            _playerRb = GetComponent<Rigidbody>();
            _focalPoint = GameObject.Find("Focal Point");
            indicatorPowerUp.SetActive(false);
            gunPowerUp.SetActive(false);
        }

        void Update()
        {
            float inputForward = Input.GetAxis("Vertical");
            _playerRb.AddForce(_focalPoint.transform.forward * (inputForward * speed));

            indicatorPowerUp.transform.position = transform.position + new Vector3(0, -0.5f, 0);
            gunPowerUp.transform.position = transform.position + new Vector3(0, 0f, 0);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent(out Boost boost))
            {
                switch (boost.type)
                {
                    case BoostType.Gun:
                        Destroy((other.gameObject));
                        gunPowerUp.SetActive(true);
                        StartCoroutine(CountDownGunRoutine());
                        break;
                    case BoostType.PowerUp:
                        hasPowerUp = true;
                        indicatorPowerUp.SetActive(true);
                        StartCoroutine(CountDownPowerUpRoutine());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Destroy(other.gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Enemy") && currentBoost.type == BoostType.PowerUp)
            {
                Rigidbody collisionRb = collision.gameObject.GetComponent<Rigidbody>() ?? throw new ArgumentNullException("collision.gameObject.GetComponent<Rigidbody>()");
                Vector3 powerUpDirection = collision.gameObject.transform.position - transform.position;
                collisionRb.AddForce(powerUpDirection * powerUpStrength, ForceMode.Impulse);
                
                Debug.Log("Collision with: " + collision.gameObject.name +" " + nameof(hasPowerUp) + " true" );
            }
        }

        IEnumerator CountDownPowerUpRoutine()
        {
            yield return new WaitForSeconds(SECONDS);
            hasPowerUp = false;
            indicatorPowerUp.SetActive(false);
        }
        IEnumerator CountDownGunRoutine()
        {
            yield return new WaitForSeconds(SECONDS);
            gunPowerUp.SetActive(false);
        }
    }
}
