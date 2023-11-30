using UnityEngine;
using UnityEngine.AI;

namespace _Root._Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMove : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.SetDestination(Vector3.zero);
        }
    }
}
