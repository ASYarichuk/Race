using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerSurface : MonoBehaviour
{
    private float _coefficientReductionOffRoadSpeed = 0.5f;

    public float CheckSurface(float speed)
    {
        RaycastHit hit = new();
        Physics.Raycast(transform.position, -transform.up * 5f, out hit);

        if (!hit.transform.GetComponent<Road>())
        {
            return speed * _coefficientReductionOffRoadSpeed;
        }

        return speed;
    }
}
