using UnityEngine;
using UnityEngine.AI;

namespace _Root._Scripts.Game
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private Transform _centerAttackSphere;
        [SerializeField] private LayerMask _layerMask;
        private Spider _spider;
        private Animator _animator;
        private NavMeshAgent _agent;
        private float _radius = 0.2f;
        private Collider[] _result;

        private void Start()
        {
            Initialize();
        }

        private void Initialize()
        {
            _result = new Collider[1];
            _spider = GetComponent<Spider>();
            _animator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Target"))
                Attacking(other);
        }

        private void Attacking(Collider other)
        {
            _agent.isStopped = true;
            _animator.SetTrigger("Attack");
        }

        public void HittingMomentEvent()
        {
            int nonAlloc = Physics.OverlapSphereNonAlloc(_centerAttackSphere.position, _radius, _result, _layerMask);
            if (nonAlloc > 0)
            {
                _result[0].GetComponent<Target>().Die();
            }
        }
    }
}