using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Profiling;
using Random = UnityEngine.Random;

namespace _Root._Scripts.Game
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class Spider : Enemy
    {
        private NavMeshAgent _agent;
        private CoverManager _coverManager;
        private CoverInfoData _nextCover;
        private CoverInfoData _currentCover;
        private bool _isInCover;
        private float _currentTimeInCover;
        private readonly float _minPlaningTime = 2f;
        private float _planingTimeInCover;
        private Vector3 _targetPosition = Vector3.zero;

        private void Start()
        {
            _coverManager = GameObject.Find("Covers").GetComponent<CoverManager>();
            _agent = GetComponent<NavMeshAgent>();
            StartMoving();
        }

        private void OnDestroy()
        {
            if (_currentCover != null)
                _coverManager.SetCoverFree(_currentCover.index);
        }

        private void Update()
        {
            CheckGameState();
            Moving();
        }

        private void Moving()
        {
            if (_isInCover)
            {
                _currentTimeInCover += Time.deltaTime;
                if (_currentTimeInCover > _planingTimeInCover)
                {
                    _currentTimeInCover = 0;
                    _isInCover = false;

                    StartMoving();
                    _coverManager.SetCoverFree(_currentCover.index);
                }
            }
        }

        private void StartMoving()
        {
            FindClosestFreeCover();
            
            if (IsCoverBusyMoveToTarget()) 
                return;

            if (IsCoverCloserThanTarget(_nextCover.position))
                MoveToCover();
            else
                MoveToTarget();
        }

        private void FindClosestFreeCover() => 
            _nextCover = _coverManager.GetClosestCover(transform.position);

        private bool IsCoverBusyMoveToTarget()
        {
            if (_nextCover == null)
            {
                MoveToTarget();
                return true;
            }
            return false;
        }

        private void MoveToCover()
        {
            _agent.SetDestination(_nextCover.position);
            _isInCover = true;
            _coverManager.SetCoverBusy(_nextCover);
            _currentCover = _nextCover;
            _planingTimeInCover = Random.Range(_minPlaningTime, _minPlaningTime + 4f);
        }

        private void MoveToTarget()
        {
            _agent.SetDestination(_targetPosition);
            if (_isInCover)
            {
                _coverManager.SetCoverFree(_nextCover.index);
                _nextCover = null;
            }
        }

        private bool IsCoverCloserThanTarget(Vector3 closestCover) =>
            Mathf.Abs(Vector3.Distance(transform.position, closestCover))
            < Mathf.Abs(Vector3.Distance(transform.position, _targetPosition));
    }
}