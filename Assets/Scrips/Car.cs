using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private int _armor;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health < 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
