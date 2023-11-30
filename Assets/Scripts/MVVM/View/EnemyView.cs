using Base;
using Enum;
using Interface;
using MVVM.Interface;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

namespace MVVM.View
{
    public class EnemyView : EnemyBase
    {
        [SerializeField] ParticleSystem deathEffect;
        [SerializeField] VisualEffect deathVFX;
        private IEnemyViewModel enemyViewModel;
        private IEnemyAI enemyAI;
        private Animator animator;
        private NavMeshAgent agent;

        public void Initialize(IEnemyViewModel enemyViewModel)
        {
            animator = GetComponent<Animator>();
            this.enemyViewModel = enemyViewModel;
            enemyViewModel.OnHpChange += Death;
            agent = GetComponent<NavMeshAgent>();
            enemyAI = new EnemyAI(transform, agent);
            events = new EventManager();
        }


        public void GetDamage(float damage)
        {
            enemyViewModel.ApplyDamage(damage);
        }

        public override void Death(float damage)
        {
            events.Notify(State.Dead);
            Destroy(Instantiate(deathVFX.gameObject, transform.position, Quaternion.identity), deathEffect.main.startLifetime.constantMax);
            gameObject.SetActive(!enemyViewModel.IsDead);
        
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void Move()
        {
            enemyAI.Move();
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
    }
}
