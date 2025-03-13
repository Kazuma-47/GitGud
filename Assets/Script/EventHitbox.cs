using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventHitbox : MonoBehaviour
{
    private bool onTriggered;

    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private UnityEvent onTriggerCollider = new();

    private void OnTriggerEnter(Collider other)
    {
        if (!onTriggered)
        {
            if (IsInLayerMask(other.gameObject))
            {
                onTriggered = true;
                onTriggerCollider?.Invoke();
            }
        }
    }

    public bool IsInLayerMask(GameObject obj)
    {
        return (playerLayer.value & (1 << obj.layer)) != 0;
    }
}
