using System;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class CatController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController _playerController;

    [Header("Movement")]
    [SerializeField] private float _catMovementSpeed = 5f;
    [SerializeField] private float _catChaseSpeed = 7f;

    [Header("Navigation")]
    [SerializeField] private float _waitTime = 2f;
    [SerializeField] private float _patrolRadius = 10f;
    [SerializeField] private int _maxDestinationAttemps = 50;
    [SerializeField] private float _chaseDistanceThreshold = 1.5f;
    [SerializeField] private float _chaseDistance = 2f;

    private NavMeshAgent _catAgent;
    private CatStateController _catStateController;
    private bool _isWaiting;
    private bool _isChasing = true;
    private float _timer;
    private Vector3 _initialPosition;

    public event Action OnCatAttackPlayer;

    void Awake()
    {
        _catAgent = GetComponent<NavMeshAgent>();
        _catStateController = GetComponent<CatStateController>();
    }

    void Start()
    {
        _initialPosition = transform.position;
        SetRandomDestination();
    }

    void Update()
    {
        if (_playerController.CanCatChase())
            SetChaseMovement();

        else if (!_playerController.CanCatChase())
            SetPatrolMovement();

            Debug.Log(_catStateController.GetCatState());
    }

    private void SetChaseMovement()
    {
        _isChasing = true;
        Vector3 directionToPlayer = (_playerController.transform.position - transform.position).normalized;
        Vector3 offsetPosition = _playerController.transform.position - directionToPlayer * _chaseDistanceThreshold;
        _catAgent.SetDestination(offsetPosition);
        _catAgent.speed = _catChaseSpeed;
        _catStateController.SetCatState(CatState.Running);

        if (Vector3.Distance(transform.position, _playerController.transform.position) <= _chaseDistance && _isChasing)
        {
            _catStateController.SetCatState(CatState.Attacking);
            OnCatAttackPlayer.Invoke();
            _isChasing = false;
        }
    }

    private void SetPatrolMovement()
    {
        _catAgent.speed = _catMovementSpeed;

        if (!_catAgent.pathPending && _catAgent.remainingDistance <= _catAgent.stoppingDistance)
        {
            if (!_isWaiting)
            {
                _isWaiting = true;
                _timer = _waitTime;
                _catStateController.SetCatState(CatState.Idle);
            }
            else if (_isWaiting)
            {
                _timer -= Time.deltaTime;
                if (_timer <= 0f)
                {
                    _isWaiting = false;
                    SetRandomDestination();
                    _catStateController.SetCatState(CatState.Walking);
                }
            }
        }
    }

    private void SetRandomDestination()
    {
        int attempts = 0;
        bool destinationSet = false;

        while (attempts < _maxDestinationAttemps && !destinationSet)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * _patrolRadius;
            randomDirection += _initialPosition;

            if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, _patrolRadius, NavMesh.AllAreas))
            {
                Vector3 finalPostion = hit.position;
                if (!IsPositionBlocked(finalPostion))
                {
                    _catAgent.SetDestination(finalPostion);
                    destinationSet = true;
                }
                else
                {
                    attempts++;
                }
            }
            else
            {
                attempts++;
            }
        }
        if (!destinationSet)
        {
            Debug.LogWarning("Destination could not be set!");
            _isWaiting = true;
            _timer = _waitTime * 2;
        }
    }

    private bool IsPositionBlocked(Vector3 position)
    {

        if (NavMesh.Raycast(transform.position, position, out NavMeshHit hit, NavMesh.AllAreas))
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 pos = (_initialPosition != Vector3.zero) ? _initialPosition : transform.position;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pos, _patrolRadius);

    }

}
