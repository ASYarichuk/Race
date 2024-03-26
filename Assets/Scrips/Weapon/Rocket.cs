using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Ammunition
{
    [SerializeField] private float _radiusBurst;
    private ParticleSystem _explosion;

    private void Awake()
    {
        _explosion = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<CapsuleCollider>().radius = _radiusBurst;
        _explosion.Play();
        //Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<CapsuleCollider>().radius = _radiusBurst;
        _explosion.Play();
    }
}
