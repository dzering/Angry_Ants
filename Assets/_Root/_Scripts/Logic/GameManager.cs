using _Root._Scripts.Data;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Root._Scripts.Logic
{
    public class GameManager : MonoBehaviour
    {
        [HideInInspector] public GameState currentState;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _bestResult;
        [SerializeField] private GameObject _gameOverPanel;
        
        private int _score;

        private void Awake()
        {
            currentState = GameState.Game;
        }

        private void UpdateBestResult(BestResult bestResult)
        {
            _bestResult.text =$"{bestResult.name}: {bestResult.score}";
        }

        private void Start()
        {
            BestResult bestResult = GameDataSingleton.instance.bestResult;
            _score = 0;
            UpdateScore(_score);
            UpdateBestResult(bestResult);
        }

        public void UpdateScore(int value)
        {
            _score += value;
            _scoreText.text = "Score: " + _score;
            GameDataSingleton.instance.UpdateScore(_score);
        }

        public void GameOver()
        {
            currentState = GameState.GameOver;
            _gameOverPanel.SetActive(true);
        }

        public void RestartGame()
        {
            GameDataSingleton.instance.SaveBestResult();
            
            _score = 0;
            UpdateScore(_score);
            currentState = GameState.Game;
            _gameOverPanel.SetActive(false);

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}


