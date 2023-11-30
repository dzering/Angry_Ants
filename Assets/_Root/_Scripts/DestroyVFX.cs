using UnityEngine;

namespace _Root._Scripts
{
    public class DestroyVFX : MonoBehaviour
    {
        [SerializeField] private float _time;

        private void Start()
        {
            _time = 3f;
            Destroy(gameObject, _time);
        }
    }
}
