using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPaint : MonoBehaviour
{
    [SerializeField] private Color _lineColor;
    [Range(0,10)][SerializeField] private float _pointRadius;

    [SerializeField] private List<Transform> _points = new();
    [SerializeField] private Transform[] _path;

    private void OnDrawGizmos()
    {
        _path = GetComponentsInChildren<Transform>();
        _points = new();

        Gizmos.color = _lineColor;

        for (int i = 1; i < _path.Length; i++)
        {
            _points.Add(_path[i]);
        }

        for (int i = 0; i < _points.Count; i++)
        {
            Vector3 currentPoint = _points[i].position;
            Vector3 previousPoint = Vector3.zero;

            if (i != 0)
            {
                previousPoint = _points[i - 1].position;
            }
            else if(i == 0)
            {
                previousPoint = _points[_points.Count - 1].position;
            }

            Gizmos.DrawLine(previousPoint, currentPoint);
            Gizmos.DrawSphere(currentPoint, _pointRadius);
        }
    }
}
