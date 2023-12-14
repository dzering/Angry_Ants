using UnityEngine;

namespace _Root._Scripts.Game
{
    public class DifficultyProperty
    {
        //"Difficulty properties"
        public int numberOfEnemySpawn;
        public float timeBetweenEnemySpawn = 4f;
        private int _maxNumber = 4;


        //"Progression properties"
        private float _timeBetweenEnemySpawnStart;

        private float _currentTime;

        public DifficultyProperty()
        {
            _maxNumber++;
            _timeBetweenEnemySpawnStart = timeBetweenEnemySpawn;
        }

        public void Execute()
        {
            if (_currentTime < timeBetweenEnemySpawn)
            {
                _currentTime += Time.deltaTime;
                return;
            }
        
            numberOfEnemySpawn++;
            numberOfEnemySpawn %= _maxNumber;
       
            if (numberOfEnemySpawn == 0)
            {
                numberOfEnemySpawn++;
                timeBetweenEnemySpawn--;
            }

            if (timeBetweenEnemySpawn == 1)
            {
                timeBetweenEnemySpawn = _timeBetweenEnemySpawnStart;
            }

            _currentTime = 0;
        }
    }
}