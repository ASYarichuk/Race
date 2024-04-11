using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    [SerializeField] private Button _rocketLauncher;

    [SerializeField] private float _currentTimeCooldown;

    private PlayerButton _buttons;

    private void Awake()
    {
        _buttons = GetComponentInParent<PlayerButton>();
        _rocketLauncher = _buttons.GiveButton(3);
        _currentTimeCooldown = GiveCooldown();
    }

    private void Update()
    {
        _currentTimeCooldown += Time.deltaTime;

        if (Input.GetMouseButtonDown(1) || _rocketLauncher.IsPressed)
        {
            _currentTimeCooldown = CreateAmmunition(_currentTimeCooldown);
        }
    }
}
