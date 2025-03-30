using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    private Ability blinkAbility;
    private Ability DashAbility;
    private Ability PhaseAbility;
    private void Start()
    {
        blinkAbility = GetComponent<BlinkAbility>();
        DashAbility = GetComponent<DashAbility>();
        PhaseAbility = GetComponent<phaseAbility>();
    }

    public void ActivateAbility(int input)
    {
        if(input == 1)
        {
            blinkAbility.OnActivate();
        }
        else if (input == 2)
        {
            print("ability 2");
            DashAbility.OnActivate();
        }
        else if(input == 3)
        {
            print("abilit 3");
            PhaseAbility.OnActivate();
        }
    }

    public void UseAbility(int input)
    {
        if (input == 1)
        {
            blinkAbility.UseAbility();
        }
        else if(input == 2)
        {
            DashAbility.UseAbility();
        }
        else if (input == 3)
        {
            PhaseAbility.UseAbility();
        }
    }
   
}
