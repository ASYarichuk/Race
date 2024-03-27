using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeLife;

    private int _damage = 0;

    private void Awake()
    {
        _damage = GetComponentInParent<Weapon>().GiveDamage();
        transform.SetParent(null);
    }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;

        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_timeLife);

        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    public int GiveDamage()
    {
        return _damage;
    }
}
