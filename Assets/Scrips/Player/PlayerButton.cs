using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerButton : MonoBehaviour
{
    [SerializeField] private Button[] _buttons = new Button[9];

    public Button GiveButton(int index)
    {
        return _buttons[index];
    }
}
