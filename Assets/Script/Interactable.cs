using UnityEngine;
using UnityEngine.Events;
public class Interactable : MonoBehaviour
{
    public bool active;
    [SerializeField] private UnityEvent onActivate = new();

    public void Activate()
    {
        if (active) 
            onActivate?.Invoke();
    }
    public void ToggleActive() => active = !active;
    

}
