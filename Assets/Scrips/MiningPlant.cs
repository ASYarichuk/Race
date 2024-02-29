using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningPlant : Weapon
{
    [SerializeField] private Button _miningPlant;

    [SerializeField] private float _currentTimeCooldown;

    private void Awake()
    {
        _currentTimeCooldown = GiveCooldown();
    }

    private void Update()
    {
        _currentTimeCooldown += Time.deltaTime;

        if (_miningPlant.IsPressed || Input.GetKey(KeyCode.Space))
        {
            _currentTimeCooldown = CreateAmmunition(_currentTimeCooldown);
        }
    }
}
