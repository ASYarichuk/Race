using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMove : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _distanceToPoint;
    [SerializeField] private float _minAcceleration;
    [SerializeField] private float _maxAcceleration;

    [SerializeField] private ControllerPoints _controllerPoints;

    private Vector3 _currentTarget;
    private int _currentNumberPoint = 0;
    private NavMeshAgent _agent;
    private float _lastRotate;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _lastRotate = transform.eulerAngles.y;
    }

    private void Start()
    {
        _currentTarget = _controllerPoints.SetPoint(_currentNumberPoint);
        _currentNumberPoint++;
        _agent.SetDestination(_currentTarget);
    }

    private void Update()
    {
        if (_lastRotate - transform.eulerAngles.y > 0.1f)
        {
            _lastRotate = transform.eulerAngles.y;

            if (_speed > 10)
            {
                _speed -= _speed > 20 ? Time.deltaTime * 100f : Time.deltaTime;
            }
        }
        else if (transform.eulerAngles.y - _lastRotate > 0.1f)
        {
            _lastRotate = transform.eulerAngles.y;

            if (_speed > 10)
            {
                _speed -= _speed > 20 ? Time.deltaTime * 100f : Time.deltaTime;
            }
        }
        else
        {
            Move();
        }

        CheckCurrentTarget();
        _agent.speed = _speed;
    }

    private void Move()
    {
        if (_speed < _maxSpeed)
        {
            _speed += Time.deltaTime * Random.Range(_minAcceleration, _maxAcceleration);
        }
    }

    private void CheckCurrentTarget()
    {
        if (Vector3.Distance(transform.position, _currentTarget) < _distanceToPoint)
        {
            _currentTarget = _controllerPoints.SetPoint(_currentNumberPoint);
            _currentNumberPoint++;
            _agent.SetDestination(_currentTarget);
        }
    }
}
