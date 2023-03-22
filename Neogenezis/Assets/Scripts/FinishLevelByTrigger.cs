using UnityEngine;
using UnityEngine.Events;

public class FinishLevelByTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _eventOnEnterActionZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.GetComponent<PlayerHealth>())
        {
            _eventOnEnterActionZone.Invoke();
        }
    }
}
