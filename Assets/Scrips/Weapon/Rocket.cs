using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Ammunition
{
    [SerializeField] private float _radiusBurst;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private float _timeLifeBurst = 0.1f;
    [SerializeField] private GameObject _body;

    private void Start()
    {
        _explosion = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Explosion();
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_timeLifeBurst);

        Destroy(_explosion.gameObject);
        Destroy(gameObject);
    }

    private void Explosion()
    {
        gameObject.GetComponent<CapsuleCollider>().radius = _radiusBurst;
        _explosion.transform.SetParent(null);
        _explosion.Play();
        gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
        _body.SetActive(false);
        StartCoroutine(Destroy());
    }
}
