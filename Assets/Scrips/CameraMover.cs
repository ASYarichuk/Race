using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    
    private Vector3 _offset;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
        _offset = transform.position - _targetTransform.position;
    }

    private void LateUpdate()
    {
        _transform.position = _targetTransform.position + _offset;
    }
}
