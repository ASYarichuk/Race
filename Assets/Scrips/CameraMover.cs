using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private float _distance;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void LateUpdate()
    {
        _transform.position = new Vector3 (_targetTransform.position.x, _transform.position.y, _targetTransform.position.z);
    }
}
