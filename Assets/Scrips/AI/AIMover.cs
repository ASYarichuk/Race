using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMover : MonoBehaviour
{
    [SerializeField] private WheelCollider[] _wheels = new WheelCollider[4];
    [SerializeField] private float _torque = 200f;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private int _forceDownMove = 2;

    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed = 90;
    [SerializeField] private float _minSpeed = 20;
    [SerializeField] private float _minSpeedDownMove = 1;
    [SerializeField] private float _angleBegoreDecrease = 10;
    [SerializeField] private float _minRatioTorqueAI = 1;
    [SerializeField] private float _maxRatioTorqueAI = 2.5f;
    [SerializeField] private float _raycastDistance = 2f;

    [SerializeField] private AIWheelsRotator _aIWheelsRotator;

    private float _ratioMinSpeed = 2.5f;
    private float _timer = 0;
    private float _timeBeforeDownMove = 0.5f;

    private RaycastHit hit = new();

    private static float _coefficientKPHInMPH = 3.6f;

    private float[] _slip = new float[4];

    private int _forceBraking = 5000;

    private float _currentAngle;
    [SerializeField] private float _mass;

    private void FixedUpdate()
    {
        Move();
        CheckAngle();
        MoveDown();
        _speed = _rigidbody.velocity.magnitude * _coefficientKPHInMPH;
        _mass = _rigidbody.mass;
    }

    private void Move()
    {
        if (_speed >= _maxSpeed)
        {
            for (int i = 0; i < _wheels.Length; i++)
            {
                _wheels[i].brakeTorque = _forceBraking;
            }
            return;
        }

        for (int i = 0; i < _wheels.Length; i++)
        {
            _wheels[i].brakeTorque = 0f;

            if (_speed < _minSpeed)
            {
                _wheels[i].motorTorque = _torque * Random.Range(_minRatioTorqueAI, _maxRatioTorqueAI) * _ratioMinSpeed;
            }
            else
            {
                _wheels[i].motorTorque = _torque * Random.Range(_minRatioTorqueAI, _maxRatioTorqueAI);
            }
        }
    }

    private void CheckAngle()
    {
        _currentAngle = _aIWheelsRotator.GiveCurrentAngle();

        if (_currentAngle > _angleBegoreDecrease && _speed > _minSpeed)
        {
            for (int i = 0; i < _wheels.Length; i++)
            {
                _wheels[i].brakeTorque = _forceBraking;
            }
        }
    }

    private void MoveDown()
    {
        if (_speed < _minSpeedDownMove)
        {
            _timer += Time.deltaTime;

            if (_timer < _timeBeforeDownMove)
            {
                return;
            }

            Physics.Raycast(transform.position, transform.forward, out hit, _raycastDistance);

            if (hit.collider == null)
            {
                _rigidbody.AddRelativeForce(-Vector3.forward * _rigidbody.mass * _forceDownMove);
                _timer = 0;
            }
        }
    }
}
