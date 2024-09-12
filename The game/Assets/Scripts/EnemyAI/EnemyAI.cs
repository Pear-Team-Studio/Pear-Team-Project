using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _roamingDistanceMax = 7.0f;
    [SerializeField] private float _roamingDistanceMin = 3.0f;
    [SerializeField] private float _roamingTimeMax = 2.0f;
    [SerializeField] private float _idleTimeMax = 3.0f;
    [SerializeField] private State _startState = State.IDLE;

    private NavMeshAgent _navMeshAgent;
    private State _state;
    private float _doingTime;
    private Vector3 _startingPosition;
    private Vector3 _roamPosition;
    private enum State
    {
        IDLE,
        Roaming
    }

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _state = _startState;
    }

    private void Start()
    {
        _startingPosition = transform.position;
    }

    private void Update()
    {
        switch (_state)
        {
            default:
                break;
            case State.IDLE:
                _doingTime -= Time.deltaTime;
                if (_doingTime < 0)
                {
                    _doingTime = _roamingTimeMax;
                    _state = State.Roaming;
                    Roaming();
                }
                break;
            case State.Roaming:
                _doingTime -= Time.deltaTime;
                if (_doingTime < 0 || transform.position == _roamPosition)
                {
                    _doingTime = _idleTimeMax;
                    _state = State.IDLE;
                }
                break;
        }
    }

    private void Roaming()
    {
        _roamPosition = GetRoamingPosition();
        _navMeshAgent.SetDestination(_roamPosition);
    }

    private Vector3 GetRoamingPosition()
    {
        return _startingPosition + MovementSystem.GetRandomDir() * UnityEngine.Random.Range(_roamingDistanceMin, _roamingDistanceMax);
    }
}
