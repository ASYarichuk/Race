using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;

    [SerializeField] private float _cooldown;

    [SerializeField] private Ammunition _bullet;

    [SerializeField] private Button _weapon;

    private float _currentTimeCooldown;

    private void Awake()
    {
        _currentTimeCooldown = _cooldown;
    }

    private void Update()
    {
        _currentTimeCooldown += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) || _weapon.IsPressed)
        {
            CreateAmmunition();
        }
    }

    private void CreateAmmunition()
    {
        if (_currentTimeCooldown >= _cooldown)
        {
            Instantiate(_bullet, transform.position, transform.rotation);
            _currentTimeCooldown = 0;
        }
    }
}
