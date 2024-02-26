using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _forceMove;
    [SerializeField] private float _maxVelocity;

    [SerializeField] private Button _gasPedal;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        AddSpeed();
        CheckVelocity();
    }

    private void AddSpeed()
    {
        Vector3 direction = transform.TransformDirection(new Vector3(0, 0, transform.localPosition.z));

        if (_gasPedal.IsPressed || Input.GetKey(KeyCode.W))
        {
            _rigidbody.AddForce(direction * _forceMove * Time.fixedDeltaTime);
        }
    }

    private void CheckVelocity()
    {
        if (_rigidbody.velocity.magnitude > _maxVelocity)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxVelocity;
        }
    }
}
