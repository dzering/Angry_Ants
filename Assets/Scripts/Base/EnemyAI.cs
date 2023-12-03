using Interface;
using UnityEngine;
using UnityEngine.AI;

namespace Base
{
    public class EnemyAI : IEnemyAI
    {
        Transform transform;
        NavMeshAgent agent;
        Vector3 boundsGameField;


        Vector3 targetPoint;

        public EnemyAI(Transform transform, NavMeshAgent navMeshAgent)
        {

            this.agent = navMeshAgent;
            this.transform = transform;
           //boundsGameField = MapGeneration.BoundsField;

            targetPoint = GetRandomPoint();
            agent.destination = targetPoint;
        }

        public void Move()
        {
            if(Vector3.Distance(transform.position, targetPoint) <= 1f)
            {
                NextPointToMove();
            }
        }

        void NextPointToMove()
        {
            targetPoint = GetRandomPoint();
            agent.destination = targetPoint;
        }

        Vector3 GetRandomPoint()
        {
            int xRandom = (int)Random.Range(-boundsGameField.x, boundsGameField.x);
            int zRandom = (int)Random.Range(-boundsGameField.z, boundsGameField.z);

            return new Vector3(xRandom, 0, zRandom);
        }
    }
}
