using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPoints : MonoBehaviour
{
    [SerializeField] private Transform[] _points;

    public Vector3 SetPoint(int numberPoint)
    {
        return _points[numberPoint].position;
    }
}
