using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : Weapon
{
    [SerializeField] private Button _machineGun;

    [SerializeField] private float _currentTimeCooldown;

    private void Awake()
    {
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
