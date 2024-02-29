using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Ammunition
{
    [SerializeField] private float _radiusBurst;

    private void OnTriggerEnter(Collider other)
    {
        gameObject.GetComponent<CapsuleCollider>().radius = _radiusBurst;
        Destroy(gameObject);
    }
}
