using UnityEngine;

namespace _Root._Scripts
{
    public class Target : MonoBehaviour
    {
        private GameManager _gameManager;

        private void Start()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        public void Die()
        {
            _gameManager.GameOver();
            Destroy(gameObject);
        }
    }
}
