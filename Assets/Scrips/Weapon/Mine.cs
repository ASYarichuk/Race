using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Ammunition
{
    [SerializeField] private float _radiusBurst;
    [SerializeField] private float _timeLifeBurst = 0.5f;
    [SerializeField] private GameObject _body;

    private ParticleSystem _explosion;

    private void Start()
    {
        _explosion = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
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
        gameObject.GetComponent<SphereCollider>().radius = _radiusBurst;
        _explosion.transform.SetParent(null);
        _explosion.Play();
        _body.SetActive(false);
        StartCoroutine(Destroy());
    }
}
