using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int _damage;

    [SerializeField] private float _cooldown;

    [SerializeField] private Ammunition _bullet;

    [SerializeField] private Transform _parent;

    public float CreateAmmunition(float currentTimeCooldown)
    {
        if (currentTimeCooldown >= _cooldown)
        {
            Instantiate(_bullet, _parent.position, _parent.rotation, _parent);
            currentTimeCooldown = 0;
            return currentTimeCooldown;
        }

        return currentTimeCooldown;
    }

    public int GiveDamage()
    {
        return _damage;
    }

    public float GiveCooldown()
    {
        return _cooldown;
    }
}
