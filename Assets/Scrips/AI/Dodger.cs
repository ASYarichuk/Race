using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodger : MonoBehaviour
{
    [SerializeField] private float _radiusRaycast;
    [SerializeField] private float _distanceRaycast;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _turningPowerLeft = -1;
    [SerializeField] private float _turningPowerRight = 1;

    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private Vector3 _eulerAngleVelocity;

    private void FixedUpdate()
    {
        RaycastHit hit = new();
        Physics.SphereCast(transform.position, _radiusRaycast, transform.forward, out hit, _distanceRaycast);

        if (hit.transform != null)
        {
            if (hit.transform.GetComponent<Bullet>())
            {
                Dodge();
            }
        }
    }

    private void Dodge()
    {
        if (_rigidbody == null)
        {
            return;
        }

        Quaternion deltaRotation = Quaternion.Euler(_eulerAngleVelocity * _speedRotate * 
            Random.Range(_turningPowerLeft, _turningPowerRight) * Time.fixedDeltaTime);

        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
    }
}
