using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodger : MonoBehaviour
{
    [SerializeField] private float _radiusRaycast;
    [SerializeField] private float _distanceRaycast;
    [SerializeField] private float _maxAngle = 60;
    [SerializeField] private float _minAngle = -60;
    [SerializeField] private float _angleTurn;

    [SerializeField] private WheelCollider[] _wheels = new WheelCollider[2];

    [SerializeField] private Rigidbody _rigidbody;

    private void FixedUpdate()
    {
        RaycastHit hit = new();
        Physics.SphereCast(transform.position, _radiusRaycast, transform.forward, out hit, _distanceRaycast);

        if (hit.collider == null)
        {
            return;
        }

        if (hit.transform.GetComponent<Bullet>())
        {
            Dodge();
        }
    }

    private void Dodge()
    {
        if (_rigidbody == null)
        {
            return;
        }

        _angleTurn = Random.Range(_minAngle, _maxAngle);

        for (int i = 0; i < _wheels.Length; i++)
        {
            _wheels[i].steerAngle = _angleTurn;
        }
    }
}
