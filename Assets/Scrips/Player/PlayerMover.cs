using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _forceMove;
    [SerializeField] private float _maxVelocity;
    [SerializeField] private float _minVelocity;
    [SerializeField] private float _currentAcceleration = 0.5f;
    [SerializeField] private float _maxAcceleration = 2f;

    [SerializeField] private Button _gasPedal;
    [SerializeField] private Button _accelerator;

    [SerializeField] private CheckerSurface _checkerSurface;

    private Rigidbody _rigidbody;

    private float _ratioAccelerator = 1.3f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
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

            if (_rigidbody.velocity.magnitude > _minVelocity)
            {
                _rigidbody.AddForce(direction * _forceMove * _currentAcceleration * _checkerSurface.CheckSurface(Time.fixedDeltaTime));
            }
            else
            {
                _rigidbody.AddForce(direction * _forceMove * _currentAcceleration);
            }
        }
    }

    private void LimitSpeed()
    {
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
