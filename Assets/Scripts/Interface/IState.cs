using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    void Walk();
    void Attack();
    void Die();
}
