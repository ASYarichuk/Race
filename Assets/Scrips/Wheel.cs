using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private Button _gasPedal;
    [SerializeField] private WheelCollider[] _wheels = new WheelCollider[4];
    [SerializeField] private float _torque = 200f;

    void FixedUpdate()
    {
        if (_gasPedal.IsPressed || Input.GetKey(KeyCode.W))
        {
            for (int i = 0; i < _wheels.Length; i++)
            {
                _wheels[i].motorTorque = _torque;
            }
        }
    }
}
