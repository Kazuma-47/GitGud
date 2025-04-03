using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [Header("Ability configuration")]
    [SerializeField] protected bool instantCast;
    [SerializeField] protected float cooldown;
    [SerializeField] protected bool abilityReady;

    [Header("Ability Events")]
    [SerializeField] protected UnityEvent OnAbiltityCooldown = new();
    [SerializeField] protected UnityEvent OnAbilityReady = new();
    
    public virtual void OnActivate()
    {
        if (instantCast)
        {
            UseAbility();
            return;
        }
    }

    public virtual void UseAbility() { }

    public virtual void StartCoolDown()
    {
        abilityReady = false;
        OnAbiltityCooldown?.Invoke();
        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        yield return new WaitForSeconds(cooldown);
        abilityReady = true;
        OnAbilityReady?.Invoke();
    }
}
