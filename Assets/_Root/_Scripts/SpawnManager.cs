using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Root._Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private Transform[] spawnPositions;
        public GameObject spawnObject;
        public bool isGameOver;
        public float spawnRate = 2f;
        private Coroutine _coroutine;

        private void Start() => 
            _coroutine = StartCoroutine(SpawnObject());

        public IEnumerator SpawnObject()
        {
            while (!isGameOver)
            {
                yield return new WaitForSeconds(spawnRate);
                Transform spawnPoint = GetSpawnPosition();
                Instantiate(spawnObject, spawnPoint.position, spawnPoint.rotation);
            }
        }

        private Transform GetSpawnPosition() => 
            spawnPositions[Random.Range(0, spawnPositions.Length)];
    }
}