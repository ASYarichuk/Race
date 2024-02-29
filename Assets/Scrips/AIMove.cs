using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    private Vector3 _nextPoint;

    private void Awake()
    {
        _nextPoint = _points[0].position;
    }
    private void Update()
    {
        if(transform.position != _nextPoint)
        {

        }
    }
}
