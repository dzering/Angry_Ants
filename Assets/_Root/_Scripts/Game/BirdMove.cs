using UnityEngine;

namespace _Root._Scripts.Game
{
    public class BirdMove : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;

        private void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
