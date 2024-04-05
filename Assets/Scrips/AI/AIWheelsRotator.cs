using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWheelsRotator : MonoBehaviour
{
    [SerializeField] private float _steerForce;

    [SerializeField] AITargetPointer _targetPointer;

    [SerializeField] private WheelCollider[] _wheels = new WheelCollider[2];

    [SerializeField] private float _angleTurn;
    [SerializeField] private float _maxAngle = 60;
    [SerializeField] private float _minAngle = -60;

    [SerializeField] private Vector3 relative;

    void FixedUpdate()
    {
        AISteer();
    }

    private void AISteer()
    {
        relative = transform.InverseTransformPoint(_targetPointer.SetTarget());
        relative /= relative.magnitude;

        _angleTurn = (relative.x / relative.magnitude) * _steerForce;

        if (_angleTurn > _maxAngle)
        {
            _angleTurn = _maxAngle;
        }

        if (_angleTurn < _minAngle)
        {
            _angleTurn = _minAngle;
        }

        for (int i = 0; i < _wheels.Length; i++)
        {
            _wheels[i].steerAngle = _angleTurn;
        }
    }

    public float GiveCurrentAngle()
    {
        return _angleTurn;
    }
}
