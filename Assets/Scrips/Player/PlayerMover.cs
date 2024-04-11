using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Button _gasPedal;
    private Button _forward;
    private Button _back;
    [SerializeField] private WheelCollider[] _wheels = new WheelCollider[4];
    [SerializeField] private float _torque = 200f;
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _speed;
    [SerializeField] private float _minSpeed = 40;
    [SerializeField] private float _maxSpeedForward = 90;
    [SerializeField] private float _maxSpeedBack = 35;

    [SerializeField] private Accelerator _accelerator;
    [SerializeField] private float _ratioAccelerator = 1f;

    private PlayerButton _buttons;

    private static float _coefficientKPHInMPH = 3.6f;

    private bool _movingForward = true;

    private float[] _slip = new float[4];

    private int _forceBraking = 5000;

    private float _ratioMinSpeed = 8f;

    private void Awake()
    {
        _buttons = GetComponentInParent<PlayerButton>();
        _gasPedal = _buttons.GiveButton(6);
        _forward = _buttons.GiveButton(7);
        _back = _buttons.GiveButton(8);
    }

    private void FixedUpdate()
    {
        SwitchCourseMovement();
        _ratioAccelerator = _accelerator.GiveRatio();
        Move();
        GetFriction();
        _speed = _rigidbody.velocity.magnitude * _coefficientKPHInMPH;
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
                if (LimitSpeeds())
                    return;

                for (int i = 0; i < _wheels.Length; i++)
                {
                    if (_speed < _minSpeed)
                    {
                        _wheels[i].brakeTorque = 0f;
                        _wheels[i].motorTorque = _torque * _ratioMinSpeed * _ratioAccelerator;
                    }
                    else
                    {
                        _wheels[i].brakeTorque = 0f;
                        _wheels[i].motorTorque = _torque * _ratioAccelerator;
                    }
                }
            }
            else
            {
                if (_speed >= _maxSpeedBack)
                    return;

                for (int i = 0; i < _wheels.Length; i++)
                {
                    _wheels[i].brakeTorque = 0f;
                    _wheels[i].motorTorque = -_torque * _ratioAccelerator;
                }
            }
        }
        else
        {
            if (_speed > 1)
            {
                for (int i = 0; i < _wheels.Length; i++)
                {
                    _wheels[i].brakeTorque = _forceBraking;
                }
            }
        }
    }

    private void GetFriction()
    {
        for (int i = 0; i < _wheels.Length; i++)
        {
            _wheels[i].GetGroundHit(out WheelHit wheelHit);
            _slip[i] = wheelHit.forwardSlip;
        }
    }

    private bool LimitSpeeds()
    {
        if (_speed >= _maxSpeedForward)
        {
            for (int i = 0; i < _wheels.Length; i++)
            {
                _wheels[i].brakeTorque = _forceBraking;
            }
            return true;
        }

        return false;
    }
}
