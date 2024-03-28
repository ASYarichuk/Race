using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] _wheels = new GameObject[4];

    private WheelCollider[] _wheelsCollider = new WheelCollider[4];

    private void Awake()
    {
        for (int i = 0; i < _wheels.Length; i++)
        {
            _wheelsCollider[i] = _wheels[i].GetComponentInChildren<WheelCollider>();
        }
    }

    private void FixedUpdate()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < _wheels.Length; i++)
        {
            _wheelsCollider[i].GetWorldPose(out wheelPosition, out wheelRotation);
            _wheels[i].transform.position = wheelPosition;
            _wheels[i].transform.rotation = wheelRotation;
        }
    }
}
