using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Ammunition
{
    [SerializeField] private float _radiusBurst;
    [SerializeField] private ParticleSystem _explosion;
    [SerializeField] private float _timeLifeBurst = 0.5f;
    [SerializeField] private float _forceGravity = 2f;
    [SerializeField] private GameObject _body;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _explosion = GetComponentInChildren<ParticleSystem>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(0, -_forceGravity, 0, ForceMode.Impulse);
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
