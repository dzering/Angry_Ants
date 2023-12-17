using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Root._Scripts.Logic
{
    public class GameManager : MonoBehaviour
    {
        public BestResult bestResult;
        [HideInInspector] public GameState currentState;
        
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _bestResultText;

        private SaveAndLoad<BestResult> _bestResultPersistence;
        private int _score;
        private bool _isNeedToUpdateResult;

        private void Awake()
        {
            currentState = GameState.Game;
            _bestResultPersistence = new SaveAndLoad<BestResult>(Application.persistentDataPath + "BestResults.json");
            bestResult = _bestResultPersistence.Load();
            _score = 0;
        }

        private void Start()
        {
            UpdateScore(_score);
            UpdateBestResult(bestResult);
        }

        public void UpdateScore(int value)
        {
            _score += value;
            _scoreText.text = "Score: " + _score;

            if (_score <= bestResult.bestScore)
                return;
            bestResult.bestScore = _score;
            UpdateBestResult(bestResult);
            _isNeedToUpdateResult = true;
        }

        public void GameOver()
        {
            currentState = GameState.GameOver;
            _gameOverPanel.SetActive(true);

            if (_isNeedToUpdateResult)
                _bestResultPersistence.Save(bestResult);
        }

        public void RestartGame()
        {
            _score = 0;
            UpdateScore(_score);
            currentState = GameState.Game;
            _gameOverPanel.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        private void UpdateBestResult(BestResult result)
        {
            string s = "BestScore: " + result.bestScore;
            _bestResultText.text = s;
        }
    }
}