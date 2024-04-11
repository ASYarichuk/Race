using UnityEngine;

public class ControlPoint : MonoBehaviour
{
    private CircleCounter _circleCounter;

    private void Awake()
    {
        _circleCounter = GetComponentInParent<CircleCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMover>())
        {
            _circleCounter.PointPassed();
        }
    }
}
