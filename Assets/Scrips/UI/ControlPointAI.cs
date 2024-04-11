using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPointAI : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CircleCounterAI circleCounterAI))
        {
            circleCounterAI.PointPassed();
        }
    }
}
