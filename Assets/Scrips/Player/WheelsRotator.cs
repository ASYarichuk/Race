using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsRotator : MonoBehaviour
{
    [SerializeField] private WheelCollider[] _wheels = new WheelCollider[2];

    [SerializeField] private float _angleTurn;

    private Button _leftTurn;
    private Button _rightTurn;

    private PlayerButton _buttons;

    private void Awake()
    {
        _buttons = GetComponentInParent<PlayerButton>();
        _leftTurn = _buttons.GiveButton(4);
        _rightTurn = _buttons.GiveButton(5);
    }

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
