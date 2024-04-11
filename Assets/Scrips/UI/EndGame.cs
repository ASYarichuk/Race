using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _finishText;
    [SerializeField] private CircleCounter _circleCounter;

    private int _place = 0;

    private void OnEnable()
    {
        _place = _circleCounter.GivePlace();
        _finishText.text = $"Гонка закончилась\n\nТвое место: {_place}";
    }
}
