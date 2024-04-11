using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlaceTakenInRace : MonoBehaviour
{
    [SerializeField] private Car[] _places = new Car[4];

    private int _currentPlace = 0;

    public void GetPlace(Car car)
    {
        _places[_currentPlace] = car;
        _currentPlace += 1;
    }

    public int GivePlace()
    {
        return _currentPlace;
    }
}
