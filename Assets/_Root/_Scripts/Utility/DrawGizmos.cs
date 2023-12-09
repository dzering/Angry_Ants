using UnityEngine;

namespace _Root._Scripts.Utility
{
    public class DrawGizmos : MonoBehaviour
    {
        [SerializeField] private Transform _centerPoint;
        [SerializeField] private float _radius;

        private void OnDrawGizmosSelected()
        {
            Gizmos.DrawSphere(_centerPoint.position, _radius);
        }
    }
}