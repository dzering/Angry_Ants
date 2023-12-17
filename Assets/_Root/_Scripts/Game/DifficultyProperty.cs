using UnityEngine;

namespace _Root._Scripts.Game
{
    public class DifficultyProperty
    {
        //"Difficulty properties"
        public int CurrentEnemiesSpawnAmount { get;private set; }
        public float TimeBetweenEnemySpawn { get; private set; } = 4f;

        private readonly int _maxEnemiesAmount = 4;
        
        private readonly float _timeBetweenEnemySpawnStart;
        private float _currentTime;

        public DifficultyProperty()
        {
            _maxEnemiesAmount++;
            _timeBetweenEnemySpawnStart = TimeBetweenEnemySpawn;
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
            if (_currentTime < TimeBetweenEnemySpawn)
            {
                _currentTime += Time.deltaTime;
                return false;
            }
            _currentTime = 0;
            return true;
        }

        private void ChangeDifficulty()
        {
            CurrentEnemiesSpawnAmount++;
            CurrentEnemiesSpawnAmount %= _maxEnemiesAmount;

            if (CurrentEnemiesSpawnAmount == 0)
            {
                CurrentEnemiesSpawnAmount++;
                TimeBetweenEnemySpawn--;
            }
        }

        private void RechargeTime()
        {
            if (TimeBetweenEnemySpawn < 1)
                TimeBetweenEnemySpawn = _timeBetweenEnemySpawnStart;
        }
    }
}