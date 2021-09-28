using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    public EventManager events;
    private NavMeshAgent navMeshAgent;
    IEnemyAI enemyAI;

    private void Start()
    {
        events = new EventManager();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAI = new EnemyAI(transform, navMeshAgent);
        enemyAI.Move();
    }

    public void Dies()
    {
        events.Notify(State.Dead);
        Destroy(gameObject);
    }
}