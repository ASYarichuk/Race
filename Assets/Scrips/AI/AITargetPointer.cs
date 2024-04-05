using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITargetPointer : MonoBehaviour
{
    [SerializeField] private ControllerPoints _controllerPoints;

    [SerializeField] private int _currentNumberPoint = 0;

    [SerializeField] private Vector3 _currentTarget;

    [SerializeField] private float _distanceToPoint;

    private void Awake()
    {
        _currentTarget = _controllerPoints.SetPoint(_currentNumberPoint);
        _currentNumberPoint++;
    }

    private void Update()
    {
        CheckCurrentTarget();
    }

    private void CheckCurrentTarget()
    {
        if (Vector3.Distance(transform.position, _currentTarget) < _distanceToPoint)
        {
            _currentTarget = _controllerPoints.SetPoint(_currentNumberPoint);
            _currentNumberPoint++;
        }
    }

    public Vector3 SetTarget()
    {
        return _currentTarget;
    }
}
