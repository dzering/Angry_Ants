using UnityEngine;

namespace _Root._Scripts.Game
{
    public class CoverManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] _covers;
        private bool[] _isBusyCovers;

        void Start() =>
            _isBusyCovers = new bool[_covers.Length];

        public void LeaveCoverFree(int currentCoverIndex) => 
            _isBusyCovers[currentCoverIndex] = false;

        public CoverInfoData GetClosestCover(Vector3 subjectPosition)
        {
            int count = 0;
            int index = 0;
            float shortestDistance = 0;

            for (int i = 0; i < _isBusyCovers.Length; i++)
            {
                if (_isBusyCovers[i])
                    continue;

                float distance = Mathf.Abs(Vector3.Distance(subjectPosition, _covers[i].transform.position));
                if (count == 0)
                {
                    count++;
                    shortestDistance = distance;
                    index = i;
                    continue;
                }
                
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    index = i;
                }
            }

            return count == 0
                ? null
                : new CoverInfoData() { index = index, position = _covers[index].transform.position };
        }

        public void SetCoverBusy(int index)
        {
            _isBusyCovers[index] = true;
        }
    }
}