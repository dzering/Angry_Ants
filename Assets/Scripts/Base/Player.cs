using MVVM.View;
using UnityEngine;

namespace Base
{
    public class Player : MonoBehaviour
    {
        public float damage = 10;
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit, Mathf.Infinity))
                {
                    if(hit.collider.TryGetComponent<EnemyView>(out var enemy))
                    {
                        enemy.GetDamage(damage);
                    }
                }
            }
        }
    }
}
