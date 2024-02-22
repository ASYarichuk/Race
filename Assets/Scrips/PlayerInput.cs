using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 _moveInput;

    public event Action PressedButton;

    public Vector3 Controls => _moveInput;

    private void Update()
    {
        _moveInput = Vector3.forward * Input.GetAxis("Horizontal");

/*        if (Input.GetButtonDown("asd"))
        {
            PressedButton?.Invoke();
        }*/
    }
}
