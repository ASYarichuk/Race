using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private Button _gasPedal;
    [SerializeField] private Button _forward;
    [SerializeField] private Button _back;
    [SerializeField] private WheelCollider[] _wheels = new WheelCollider[4];
    [SerializeField] private float _torque = 200f;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _kmPerHour;

    private static float _coefficientKPHInMPH = 3.6f;

    private bool _movingForward = true;

    private void FixedUpdate()
    {
        _kmPerHour = _rigidbody.velocity.magnitude * _coefficientKPHInMPH;
        SwitchCourseMovement();
        Move();
    }

    private void SwitchCourseMovement()
    {
        if (_forward.IsPressed || Input.GetKey(KeyCode.Q))
        {
            _movingForward = true;
        }

        if (_back.IsPressed || Input.GetKey(KeyCode.E))
        {
            _movingForward = false;
        }
    }

    private void Move()
    {
        if (_gasPedal.IsPressed || Input.GetKey(KeyCode.W))
        {
            if (_movingForward)
            {
                for (int i = 0; i < _wheels.Length; i++)
                {
                    _wheels[i].motorTorque = _torque;
                }
            }
            else
            {
                for (int i = 0; i < _wheels.Length; i++)
                {
                    _wheels[i].motorTorque = -_torque;
                }
            }
        }
    }
}
