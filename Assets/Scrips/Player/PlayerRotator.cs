using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _forceRotate;

    [SerializeField] private float _speedRotate;

    [SerializeField] private Vector3 _eulerAngleVelocityLeft;
    [SerializeField] private Vector3 _eulerAngleVelocityRight;

    [SerializeField] private Button _leftTurn;
    [SerializeField] private Button _rightTurn;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    public void Rotate()
    {
        Quaternion deltaRotationLeft = Quaternion.Euler(_eulerAngleVelocityLeft * _speedRotate * Time.fixedDeltaTime);
        Quaternion deltaRotationRight = Quaternion.Euler(_eulerAngleVelocityRight * _speedRotate * Time.fixedDeltaTime);

        if (_leftTurn.IsPressed || Input.GetKey(KeyCode.A))
        {
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotationLeft);
        }
        
        if (_rightTurn.IsPressed || Input.GetKey(KeyCode.D))
        {
            _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotationRight);
        }
    }
}
