using _Root._Scripts.Logic;
using UnityEngine;

namespace _Root._Scripts.Game
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private ParticleSystem deathParticleSystem;
        [SerializeField] private int _score = 5;
        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void OnMouseDown()
        {
            if (СanKillEnemy())
            {
                DestroyEnemy();
            }
        }

        private void DestroyEnemy()
        {
            Instantiate(deathParticleSystem, transform.position, deathParticleSystem.transform.rotation);
            _enemy.Manager.UpdateScore(_score);
            SoundManager.Instance.PlaySlap();
            Destroy(gameObject);
        }

        private bool СanKillEnemy()
        {
            return gameObject.CompareTag("Enemy") && _enemy.Manager.currentState == GameState.Game;
        }
    }
}
