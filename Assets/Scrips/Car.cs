using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _armor;

    private float _damageMultiplier;
    private float _currentDamage;

    public void TakeDamage(int damage)
    {
        _damageMultiplier = damage / (damage + _armor);
        _currentDamage = damage * _damageMultiplier;

        _health -= _currentDamage;

        if (_health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ammunition ammunition))
        {
           TakeDamage(ammunition.GiveDamage());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out Ammunition ammunition))
        {
            TakeDamage(ammunition.GiveDamage());
        }
    }
}
