using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _forceMove;
    [SerializeField] private float _maxVelocity;
    [SerializeField] private float _startValueAcceleration = 0.5f;
    [SerializeField] private float _maxAcceleration = 2f;
    [SerializeField] private float _currentSpeed;

    [SerializeField] private Button _gasPedal;
    [SerializeField] private Button _accelerator;

    private Rigidbody _rigidbody;

    private float _ratioAccelerator = 1.3f;

    [SerializeField] private float _currentAcceleration;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _currentAcceleration = _startValueAcceleration;
    }

    private void FixedUpdate()
    {
        AddSpeed();
        LimitSpeed();
    }

    private void AddSpeed()
    {
        Vector3 direction = transform.TransformDirection(new Vector3(0, 0, transform.localPosition.z));

        if (_gasPedal.IsPressed || Input.GetKey(KeyCode.W))
        {
            _currentAcceleration += Time.fixedDeltaTime;

            if (_accelerator.IsPressed || Input.GetKey(KeyCode.V))
            {
                _currentAcceleration *= _ratioAccelerator;
            }

            if (_currentAcceleration > _maxAcceleration)
            {
                _currentAcceleration = _maxAcceleration;
            }

            _rigidbody.AddForce(direction * _forceMove * _currentAcceleration * Time.fixedDeltaTime);
        }
    }

    private void LimitSpeed()
    {
        _currentSpeed = _rigidbody.velocity.magnitude;

        if (_rigidbody.velocity.magnitude > _maxVelocity)
        {
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxVelocity;
        }
    }

    public void SetRatioAccelerator(float ratioAccelerator)
    {
        _ratioAccelerator = ratioAccelerator;
    }
}
