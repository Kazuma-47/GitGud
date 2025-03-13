using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DoorHandler : MonoBehaviour
{
    [Header("Open Door Positions")]
    [SerializeField] private bool locked;
    [SerializeField] private Vector3 OpenPosition;
    [SerializeField] private Vector3 OpenRotation;

    [SerializeField] private UnityEvent onOpenDoor = new();
    [SerializeField] private UnityEvent onLockedDoor = new();
  public void OpenDoor()
  {
        if (!locked)
        {
            transform.localPosition = OpenPosition;
            transform.rotation = Quaternion.Euler(OpenRotation);
            DoorOpenEvent(); 
        }
        else
            DoorLockEvent();
  }

    public void ToggleDoorLock() => locked = !locked;

    public void DoorOpenEvent() => onOpenDoor?.Invoke();
    public void DoorLockEvent() => onLockedDoor?.Invoke();


}
