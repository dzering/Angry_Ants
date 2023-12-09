using UnityEngine;
using Random = UnityEngine.Random;

namespace Course_Library.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject[] enemyPrefabs;
        public GameObject[] powerUpPrefab;
        public int enemyCount;
        public int waveNumber = 1;

        public float randomRange = 9;
        // Start is called before the first frame update
        void Start()
        {
            SpawnEnemyWave(waveNumber);
        }

        private void Update()
        {
            enemyCount = FindObjectsOfType<EnemyOld>().Length;
            if(enemyCount == 0)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
            }
        }

        private void SpawnEnemyWave(int enemyToSpawn)
        {
            GameObject prefab = GetRandomPrefab(powerUpPrefab);
            Instantiate(prefab, GenerateSpawnPosition(), prefab.transform.rotation);
            
            for (int i = 0; i < enemyToSpawn; i++)
            {
                GameObject enemyPrefab = GetRandomPrefab(enemyPrefabs);
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }

        private GameObject GetRandomPrefab(GameObject[] gameObjects)
        {
            return gameObjects[Random.Range(0, gameObjects.Length)];
        }

        private Vector3 GenerateSpawnPosition()
        {
            float randomX = Random.Range(-randomRange, randomRange);
            float randomZ = Random.Range(-randomRange, randomRange);
            Vector3 spawnPosition = new Vector3(randomX, 0, randomZ);
            return spawnPosition;
        }
    }
}
