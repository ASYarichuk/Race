using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningPlant : Weapon
{
    [SerializeField] private Button _miningPlant;

    [SerializeField] private float _currentTimeCooldown;

    private PlayerButton _buttons;

    private void Awake()
    {
        _buttons = GetComponentInParent<PlayerButton>();
        _miningPlant = _buttons.GiveButton(0);
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
