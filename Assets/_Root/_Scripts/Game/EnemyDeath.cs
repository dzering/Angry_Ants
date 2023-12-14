using _Root._Scripts.Logic;
using UnityEngine;

namespace _Root._Scripts.Game
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private int _score = 5;
        public ParticleSystem deathParticleSystem;
        private Enemy _enemy;

        private void Start()
        {
            _enemy = GetComponent<Enemy>();
        }

        private void OnMouseDown()
        {
            if (gameObject.CompareTag("Enemy") && _enemy.gameManager.currentState == GameState.Game)
            {
                Instantiate(deathParticleSystem, transform.position, deathParticleSystem.transform.rotation);
                _enemy.gameManager.UpdateScore(_score);
                SoundManager.instance.PlaySlap();
                Destroy(gameObject);
            }
        }
    }
}
