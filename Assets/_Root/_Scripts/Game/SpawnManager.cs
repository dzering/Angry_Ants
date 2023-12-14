using System.Collections;
using _Root._Scripts.Logic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Root._Scripts.Game
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Transform[] _spawnPositions;
        public GameObject spawnObject;
        
        private Coroutine _coroutine;
        private DifficultyProperty _difficulty;

        public void Start()
        {
            _difficulty = new DifficultyProperty();
            _gameManager ??= GameObject.Find("GameManager").GetComponent<GameManager>();
            RestartGame();
        }

        private void Update()
        {
            _difficulty.Execute();
        }

        private void RestartGame()
        {
            _coroutine = StartCoroutine(SpawnObject());
        }

        public IEnumerator SpawnObject()
        {
            while (_gameManager.currentState == GameState.Game)
            {
                yield return new WaitForSeconds(_difficulty.timeBetweenEnemySpawn);
                SpawnEnemies(_difficulty.numberOfEnemySpawn);
            }
        }

        private void SpawnEnemies(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Transform spawnPoint = GetSpawnPosition();
                GameObject instantiate = Instantiate(spawnObject, spawnPoint.position, spawnPoint.rotation);
                Enemy enemy = instantiate.GetComponent<Enemy>();
                enemy.Construct(_gameManager);
            }
        }

        private Transform GetSpawnPosition() => 
            _spawnPositions[Random.Range(0, _spawnPositions.Length)];
    }
}