using UnityEngine;

namespace _Root._Scripts.Game
{
    public class DifficultyProperty
    {
        //"Difficulty properties"
        public int currentEnemiesSpawnAmount;
        public float timeBetweenEnemySpawn = 4f;
        private readonly int _maxEnemiesAmount = 4;
        
        private readonly float _timeBetweenEnemySpawnStart;
        private float _currentTime;

        public DifficultyProperty()
        {
            _maxEnemiesAmount++;
            _timeBetweenEnemySpawnStart = timeBetweenEnemySpawn;
        }

        public void Execute()
        {
            if (!IsReadyNextChangeDifficulty()) 
                return;
        
            ChangeDifficulty();
            RechargeTime();
        }

        private bool IsReadyNextChangeDifficulty()
        {
            if (_currentTime < timeBetweenEnemySpawn)
            {
                _currentTime += Time.deltaTime;
                return false;
            }
            _currentTime = 0;
            return true;
        }

        private void ChangeDifficulty()
        {
            currentEnemiesSpawnAmount++;
            currentEnemiesSpawnAmount %= _maxEnemiesAmount;

            if (currentEnemiesSpawnAmount == 0)
            {
                currentEnemiesSpawnAmount++;
                timeBetweenEnemySpawn--;
            }
        }

        private void RechargeTime()
        {
            if (timeBetweenEnemySpawn < 1)
                timeBetweenEnemySpawn = _timeBetweenEnemySpawnStart;
        }
    }
}