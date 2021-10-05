using UnityEngine;
using UnityEngine.AI;

public abstract class EnemyBase : MonoBehaviour
{
    public ISubject EventM { get; set; }
    public abstract void Death(float damage);
}
