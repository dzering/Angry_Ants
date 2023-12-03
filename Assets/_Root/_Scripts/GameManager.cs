using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Root._Scripts
{
    public class GameManager : MonoBehaviour
    {
        [HideInInspector] public GameState currentState;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private GameObject _gameOverPanel;
        
        private int _score;

        private void Awake()
        {
            currentState = GameState.Game;
        }

        private void Start()
        {
            _score = 0;
            UpdateScore(_score);
        }

        public void UpdateScore(int value)
        {
            _score += value;
            _scoreText.text = "Score: " + _score;
        }

        public void GameOver()
        {
            currentState = GameState.GameOver;
            _gameOverPanel.SetActive(true);
        }

        public void RestartGame()
        {
            _score = 0;
            UpdateScore(_score);
            currentState = GameState.Game;
            _gameOverPanel.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}


