using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AIMove : MonoBehaviour
{
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _distanceToPoint;
    [SerializeField] private float _minAcceleration;
    [SerializeField] private float _maxAcceleration;
    [SerializeField] private float _slowSpeedTurnOne = 100f;
    [SerializeField] private float _slowSpeedTurnTwo = 200f;
    [SerializeField] private float _slowSpeedTurnThree = 300f;
    [SerializeField] private float _minAngleRotate = 0.1f;
    [SerializeField] private float _speedLimitTurnLevelOne = 15f;
    [SerializeField] private float _speedLimitTurnLevelTwo = 20f;
    [SerializeField] private float _speedLimitTurnLevelThree = 35f;

    [SerializeField] private ControllerPoints _controllerPoints;

    [SerializeField] private CheckerSurface _checkerSurface;

    private Vector3 _currentTarget;
    private int _currentNumberPoint = 0;
    private NavMeshAgent _agent;
    private float _lastRotate;
    private float _maxSpeedLimitTurn;

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
        _speed = _startSpeed;
    }

    private void Update()
    {
        CheckAngle();
        CheckCurrentTarget();
        _agent.speed = _speed;
    }

    private void Move()
    {
        if (_speed < _maxSpeed)
        {
            _speed += _checkerSurface.CheckSurface(Time.deltaTime) * Random.Range(_minAcceleration, _maxAcceleration);
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

    private void CheckAngle()
    {
        if (_lastRotate - transform.eulerAngles.y > _minAngleRotate)
        {
            DecreaseSpeed();
        }
        else if (transform.eulerAngles.y - _lastRotate > _minAngleRotate)
        {
            DecreaseSpeed();
        }
        else
        {
            Move();
        }
    }

    private void DecreaseSpeed()
    {
        _lastRotate = transform.eulerAngles.y;

        if (_speed > _speedLimitTurnLevelThree)
        {
            _speed -= _speed > _maxSpeedLimitTurn ? _checkerSurface.CheckSurface(Time.deltaTime) *
                _slowSpeedTurnThree : _checkerSurface.CheckSurface(Time.deltaTime);
        }
        else if (_speed > _speedLimitTurnLevelTwo)
        {
            _speed -= _speed > _maxSpeedLimitTurn ? _checkerSurface.CheckSurface(Time.deltaTime) *
                _slowSpeedTurnTwo : _checkerSurface.CheckSurface(Time.deltaTime);
        }
        else if (_speed > _speedLimitTurnLevelOne)
        {
            _speed -= _speed > _maxSpeedLimitTurn ? _checkerSurface.CheckSurface(Time.deltaTime) *
                _slowSpeedTurnOne : _checkerSurface.CheckSurface(Time.deltaTime);
        }
    }
}
