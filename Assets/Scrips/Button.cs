using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool _isPressed = false;

    public bool IsPressed => _isPressed;

    public void CheckPress(bool isPressed)
    {
        _isPressed = isPressed;
    }
}
