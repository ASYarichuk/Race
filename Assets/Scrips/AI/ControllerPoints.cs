using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPoints : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    [SerializeField] private float _minValueOffset;
    [SerializeField] private float _maxValueOffset;

    private float _offsetX;
    private float _offsetZ;

    private Vector3 _target;

    public Vector3 SetPoint(int numberPoint)
    {
        _offsetX = Random.Range(_minValueOffset, _maxValueOffset);
        _offsetZ = Random.Range(_minValueOffset, _maxValueOffset);

        _target = _points[numberPoint].position;
        _target = new Vector3(_target.x + _offsetX, _target.y, _target.z + _offsetZ);

        return _target;
    }
}
