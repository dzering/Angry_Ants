using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float power = 100f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 direction = collision.transform.position - transform.position;
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            enemyRb.AddForce(direction * power, ForceMode.Impulse);
            Debug.Log(this.gameObject.name + " contact with " + collision.gameObject.name);
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if((Vector3.zero - transform.position).sqrMagnitude > 400)
            Destroy(gameObject);
    }
}
