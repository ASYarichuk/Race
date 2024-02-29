using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerator : MonoBehaviour
{
    [SerializeField] private float _ratioAcceleration = 1f;

    private PlayerMover _playerMover;

    private void Awake()
    {
        _playerMover = GetComponentInParent<PlayerMover>();
    }

    private void Start()
    {
        _playerMover.SetRatioAccelerator(_ratioAcceleration);
    }
}
