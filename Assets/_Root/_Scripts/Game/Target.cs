using _Root._Scripts.Logic;
using UnityEngine;

namespace _Root._Scripts.Game
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
