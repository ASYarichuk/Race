using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    [SerializeField] private Button _machineGun;

    [SerializeField] private float _currentTimeCooldown;

    private PlayerButton _buttons;

    private void Awake()
    {
        _buttons = GetComponentInParent<PlayerButton>();
        _machineGun = _buttons.GiveButton(2);
        _currentTimeCooldown = GiveCooldown();
    }

    private void Update()
    {
        _currentTimeCooldown += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) || _machineGun.IsPressed)
        {
            _currentTimeCooldown = CreateAmmunition(_currentTimeCooldown);
        }
    }
}
