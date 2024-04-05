using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMover : MonoBehaviour
{
    [SerializeField] private WheelCollider[] _wheels = new WheelCollider[4];
    [SerializeField] private float _torque = 200f;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed = 90;
    [SerializeField] private float _minSpeed = 20;
    [SerializeField] private float _angleBegoreDecrease = 10;

    [SerializeField] private AIWheelsRotator _aIWheelsRotator;

    private static float _coefficientKPHInMPH = 3.6f;

    private float[] _slip = new float[4];

    private int _forceBraking = 5000;

    private float _currentAngle;

    private void FixedUpdate()
    {
        Move();
        CheckAngle();
        _speed = _rigidbody.velocity.magnitude * _coefficientKPHInMPH;
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
                _wheels[i].motorTorque = _torque * 2;
            }
            else
            {
                _wheels[i].motorTorque = _torque;
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
}
