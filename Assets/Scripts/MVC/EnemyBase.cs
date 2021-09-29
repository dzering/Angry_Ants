using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    public EventManager Events;
    private NavMeshAgent navMeshAgent;
    IEnemyAI enemyAI;

    private void Start()
    {
        Events = new EventManager();
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAI = new EnemyAI(transform, navMeshAgent);
        enemyAI.Move();
    }

    public void Dies()
    {
        Events.Notify(State.Dead);
        Destroy(gameObject);
    }
}
