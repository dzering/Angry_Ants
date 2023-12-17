using UnityEngine;
using UnityEngine.AI;

namespace _Root._Scripts.Game
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;
        private static readonly int Speed = Animator.StringToHash("Speed");

        void Start()
        {
            if (_animator == null)
                _animator = GetComponent<Animator>();
            if (_agent == null)
                _agent = GetComponent<NavMeshAgent>();
        }
        
        void Update()
        {
            PlayAnimation();
        }

        private void PlayAnimation()
        {
            _animator.SetFloat(Speed, _agent.velocity.sqrMagnitude);
            _animator.speed = _agent.speed;
        }
    }
}