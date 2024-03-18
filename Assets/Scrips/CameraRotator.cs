using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;

    [SerializeField] private Vector3 _startValue;
    [SerializeField] private Vector3 _axis;

    private float _currentRotationTarget;
    private float _startRotationTarget;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _startRotationTarget = _targetTransform.eulerAngles.y;
    }

    private void LateUpdate()
    {
        _currentRotationTarget = _targetTransform.eulerAngles.y;

            transform.RotateAround(_targetTransform.position, _axis, 1 * Time.fixedDeltaTime);

        //transform.position = objectToOrbit.position - (transform.forward * radius);
        // https://gamedevbeginner.com/how-to-rotate-in-unity-complete-beginners-guide/#rotate_camera

        if (_currentRotationTarget < _startRotationTarget - 30)
        {
            _transform.RotateAround(_targetTransform.position, _axis, -30);
            _startRotationTarget = _currentRotationTarget;
        }
    }
}
