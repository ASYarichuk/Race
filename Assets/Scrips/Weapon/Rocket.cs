using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Ammunition
{
    [SerializeField] private float _radiusBurst;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private float _timeLifeBurst = 0.1f;

    private void Start()
    {
        _explosion = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<Road>())
        {
            gameObject.GetComponent<CapsuleCollider>().radius = _radiusBurst;
            _explosion.Play();
            StartCoroutine(Destroy());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.GetComponent<CapsuleCollider>().radius = _radiusBurst;
        _explosion.Play();
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_timeLifeBurst);

        Destroy(gameObject);
    }
}
