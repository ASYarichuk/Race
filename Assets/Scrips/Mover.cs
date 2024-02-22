using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private int _speed;

    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerInput = gameObject.AddComponent<PlayerInput>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.AddForce(Vector3.forward * Input.GetAxis("Horizontal") * _speed);
    }
}
