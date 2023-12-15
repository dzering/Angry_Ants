using UnityEngine;

namespace _Root._Scripts.Game
{
    public class DestroyVFX : MonoBehaviour
    {
        private const float TIME = 3f;

        private void Start()
        {
            Destroy(gameObject, TIME);
        }
    }
}
