using System.Collections;
using _Root._Scripts.Logic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Root._Scripts.Game
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _spiderPrefab;
        [SerializeField] private GameObject _birdPrefab;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Transform[] _spawnSpiderPositions;

        private DifficultyProperty _difficulty;

        public void Start()
        {
            Initialization();
            StartSpawns();
        }

        private void Update()
        {
            _difficulty.Execute();
        }

        private void Initialization()
        {
            _difficulty = new DifficultyProperty();
            _gameManager ??= GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void StartSpawns()
        {
            StartCoroutine(SpawnSpidersCoroutine());
            StartCoroutine(SpawnBirdCoroutine());
        }

        private IEnumerator SpawnSpidersCoroutine()
        {
            while (_gameManager.currentState == GameState.Game)
            {
                yield return new WaitForSeconds(_difficulty.TimeBetweenEnemySpawn);
                SpawnSpiders(_difficulty.CurrentEnemiesSpawnAmount);
            }
        }

        private void SpawnSpiders(int number)
        {
            for (int i = 0; i < number; i++)
            {
                Transform spawnPoint = GetSpawnPosition();
                InstantiateAndInitialize(_spiderPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }

        private IEnumerator SpawnBirdCoroutine()
        {
            while (_gameManager.currentState == GameState.Game)
            {
                yield return new WaitForSeconds(10f);
                Vector3 spawnPosition = new Vector3(Random.Range(-10, 10), 2f, -16f);
                InstantiateAndInitialize(_birdPrefab, spawnPosition, Quaternion.identity);
            }
        }

        private void InstantiateAndInitialize(GameObject prefabEnemy, Vector3 position, Quaternion rotation)
        {
            GameObject instantiate = Instantiate(prefabEnemy, position, rotation);
            Enemy spider = instantiate.GetComponent<Enemy>();
            spider.Construct(_gameManager);
        }

        private Transform GetSpawnPosition() => 
            _spawnSpiderPositions[Random.Range(0, _spawnSpiderPositions.Length)];
    }
}