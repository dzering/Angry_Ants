using Interface;
using UnityEngine;

namespace Base
{
    public abstract class EnemyBase : MonoBehaviour
    {
        public ISubject events { get; set; }
        public abstract void Death(float damage);
        public abstract void Move();
    }
}
