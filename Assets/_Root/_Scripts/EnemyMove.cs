using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace _Root._Scripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyMove : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private GameManager _gameManager;
        private CoverManager _coverManager;
        private CoverInfoData _nextCoverInfo;
        private CoverInfoData _currentCoverInfo;
        private bool _isInCover;
        private float _timeInCover;
        private readonly float _planingTime = 3f;
        private Vector3 _targetPosition = Vector3.zero;

        private void Start()
        {
            Initialization();
            MoveTo();
        }

        private void Update()
        {
            if (_gameManager.currentState != GameState.Game)
            {
                _agent.isStopped = true;
                Destroy(gameObject);
            }

            if (_isInCover)
            {
                _timeInCover += Time.deltaTime;
                if (_timeInCover > Random.Range(_planingTime, _planingTime + 2))
                {
                    _timeInCover = 0;
                    _isInCover = false;
                    
                    MoveTo();
                    _coverManager.LeaveCoverFree(_currentCoverInfo.index);
                }
            }
        }

        private void Initialization()
        {
            _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            _coverManager = GameObject.Find("Covers").GetComponent<CoverManager>();
            _agent = GetComponent<NavMeshAgent>();
        }

        private void MoveTo()
        {
            _nextCoverInfo = _coverManager.GetClosestCover(transform.position);

            if (CoversAreBusyMoveToTarget()) return;

            if (CoverIsCloserThanTarget(_nextCoverInfo.position))
            {
                MoveToCover();
            }
            else
            {
                MoveToTarget();
            }
        }

        private void MoveToTarget()
        {
            _agent.SetDestination(_targetPosition);
            if (_isInCover)
            {
                _coverManager.LeaveCoverFree(_nextCoverInfo.index);
                _nextCoverInfo = null;
            }
        }

        private void MoveToCover()
        {
            _agent.SetDestination(_nextCoverInfo.position);
            _isInCover = true;
            _coverManager.SetCoverBusy(_nextCoverInfo.index);
            _currentCoverInfo = _nextCoverInfo;
        }

        private void OnDestroy()
        {
            if (_currentCoverInfo != null)
                _coverManager.LeaveCoverFree(_currentCoverInfo.index);
        }

        private bool CoversAreBusyMoveToTarget()
        {
            if (_nextCoverInfo == null)
            {
                _agent.SetDestination(_targetPosition);
                return true;
            }

            return false;
        }

        private bool CoverIsCloserThanTarget(Vector3 closestCover) =>
            Mathf.Abs(Vector3.Distance(transform.position, closestCover))
            < Mathf.Abs(Vector3.Distance(transform.position, _targetPosition));
    }
}