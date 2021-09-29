using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : IEnemyAI
{
    Transform transform;
    NavMeshAgent navMeshAgent;
    Vector3 boundsGameField;
    Vector3 destinationPoint;
    Vector3 targetPoint;

    public EnemyAI(Transform transform, NavMeshAgent navMeshAgent)
    {
        this.navMeshAgent = navMeshAgent;
        this.transform = transform;
        boundsGameField = MapGeneration.GetBounds();

        targetPoint = GetRandomPoint();
        navMeshAgent.destination = targetPoint;
        destinationPoint = navMeshAgent.destination;
    }

    public void Move()
    {
        if(Vector3.Distance(transform.position, destinationPoint) < 0.3f)
        {
            FindPath();
        }
    }

    void FindPath()
    {
        targetPoint = GetRandomPoint();
        destinationPoint = targetPoint;
    }

    Vector3 GetRandomPoint()
    {
        int xRandom = (int)Random.Range(-boundsGameField.x, boundsGameField.x);
        int zRandom = (int)Random.Range(-boundsGameField.y, boundsGameField.y);

        return new Vector3(xRandom, 0, zRandom);
    }
}
