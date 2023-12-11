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
        
        public float spawnRate = 3f;
        private Coroutine _coroutine;
        private int _numberEnemies = 1;

        public void Start()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            RestartGame();
        }

        private void RestartGame()
        {
            _coroutine = StartCoroutine(SpawnObject());
        }

        public IEnumerator SpawnObject()
        {
            while (_gameManager.currentState == GameState.Game)
            {
                yield return new WaitForSeconds(spawnRate);
                SpawnEnemies(_numberEnemies);
                _numberEnemies++;
            }
        }

        private void SpawnEnemies(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Transform spawnPoint = GetSpawnPosition();
                Instantiate(spawnObject, spawnPoint.position, spawnPoint.rotation);
            }
        }

        private Transform GetSpawnPosition() => 
            _spawnPositions[Random.Range(0, _spawnPositions.Length)];
    }
}