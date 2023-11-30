using System;

namespace MVVM.Interface
{
    public interface IEnemyViewModel
    {
        IEnemyModel enemyModel { get; }
        bool IsDead { get; }
        void ApplyDamage(float damage);
        event Action<float> OnHpChange;
    }
}
