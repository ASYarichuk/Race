using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeapon : Weapon
{
    [SerializeField] private float _currentTimeCooldown;

    private void Awake()
    {
        _currentTimeCooldown = GiveCooldown();
    }

    private void Update()
    {
        _currentTimeCooldown += Time.deltaTime;

        RaycastHit hit = new();
        Physics.Raycast(transform.position, transform.forward, out hit);

        if(hit.transform.GetComponent<Car>())
        {
            _currentTimeCooldown = CreateAmmunition(_currentTimeCooldown);
        }
    }
}
