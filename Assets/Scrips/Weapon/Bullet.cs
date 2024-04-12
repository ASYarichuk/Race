using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Ammunition
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

}
