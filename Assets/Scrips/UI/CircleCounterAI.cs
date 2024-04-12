using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCounterAI : MonoBehaviour
{
    private PlaceTakenInRace _placeTakenInRace;

    [SerializeField] private int _maxCircle = 3;
    [SerializeField] private int _maxPoint = 4;

    [SerializeField] private int _currentCircle = 0;
    [SerializeField] private int _currentPoint = 0;

    private void Awake()
    {
        _placeTakenInRace = FindObjectOfType<PlaceTakenInRace>();
    }

    public void PointPassed()
    {
        _currentPoint += 1;

        if (_currentPoint >= _maxPoint)
        {
            _currentCircle += 1;
            _currentPoint = 0;
        }

        if (_currentCircle == _maxCircle)
        {
            _placeTakenInRace.GetPlace(GetComponent<Car>());
        }
    }
}
