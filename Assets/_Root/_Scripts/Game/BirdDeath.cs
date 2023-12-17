using System;

namespace _Root._Scripts.Game
{
    public class BirdDeath : EnemyDeath
    {
        private void Update()
        {
            if(transform.position.z > 10)
                Destroy(gameObject);
        }
    }
}
