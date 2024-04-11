using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControlPoints : MonoBehaviour
{
    [SerializeField] private ControlPoint[] _controlPoints = new ControlPoint[4];

    private int _currentPoint;

    private void Start()
    {
        _currentPoint = 0;
        _controlPoints[_currentPoint].gameObject.SetActive(true);
    }

    public int ActiveNextPoint()
    {
        _controlPoints[_currentPoint].gameObject.SetActive(false);
        _currentPoint += 1;

        if (_currentPoint >= _controlPoints.Length)
        {
            _currentPoint = 0;
        }

        _controlPoints[_currentPoint].gameObject.SetActive(true);

        return _currentPoint;
    }
}
