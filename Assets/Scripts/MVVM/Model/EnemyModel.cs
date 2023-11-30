using MVVM.Interface;

namespace MVVM.Model
{
    public class EnemyModel : IEnemyModel
    {
        public float MaxHP { get; }
        public float CurrentHP { get; set; } 
        public EnemyModel(float maxHP)
        {
            MaxHP = maxHP;
            CurrentHP = MaxHP;
        }
    }
}
