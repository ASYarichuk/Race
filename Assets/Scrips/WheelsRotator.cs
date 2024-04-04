using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsRotator : MonoBehaviour
{
    [SerializeField] private WheelCollider[] _wheels = new WheelCollider[2];

    [SerializeField] private float _angleTurn;

    [SerializeField] private Button _leftTurn;
    [SerializeField] private Button _rightTurn;

    void FixedUpdate()
    {
        if (_leftTurn.IsPressed || Input.GetKey(KeyCode.A))
        {
            for (int i = 0; i < _wheels.Length; i++)
            {
                _wheels[i].steerAngle = -_angleTurn;
            }
        }
        else if(_rightTurn.IsPressed || Input.GetKey(KeyCode.D))
        {
            for (int i = 0; i < _wheels.Length; i++)
            {
                _wheels[i].steerAngle = _angleTurn;
            }
        }
        else
        {
            for (int i = 0; i < _wheels.Length; i++)
            {
                _wheels[i].steerAngle = 0;
            }
        }
    }
}
