using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    [SerializeField] private float _ratio = 5f;
    [SerializeField] private float _startRatio = 1f;
    [SerializeField] private Button _acceleration;
    [SerializeField] private float _time;
    [SerializeField] private float _cooldown;

    private float _currentTime = 0f;
    private float _currentRatio = 1f;

    private PlayerButton _buttons;

    private void Awake()
    {
        _buttons = GetComponentInParent<PlayerButton>();
        _acceleration = _buttons.GiveButton(1);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_acceleration.IsPressed || Input.GetKeyDown(KeyCode.V))
        {
            if (_currentTime > _cooldown)
            {
                StartCoroutine(SpeedUp());
                _currentTime = 0f;
            }
        }
    }

    private IEnumerator SpeedUp()
    {
        _currentRatio = _ratio;
        yield return new WaitForSeconds(_time);
        _currentRatio = _startRatio;
    }

    public float GiveRatio()
    {
        return _currentRatio;
    }
}
