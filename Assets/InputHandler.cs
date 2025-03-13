using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] public Controls inputActions;
    private PlayerMovement playerMovement;
    private AbilityManager abilityManager;
    private bool isAiming;

    private void Start()
    {
        inputActions = new Controls();
        inputActions.PlayerMovement.Enable();
        inputActions.Abilities.Enable();
        playerMovement = GetComponent<PlayerMovement>();
        abilityManager = GetComponent<AbilityManager>();
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = inputActions.PlayerMovement.Movement.ReadValue<Vector2>();
        playerMovement.MovePlayer(movementInput);

        inputActions.PlayerMovement.Jump.performed += (InputAction.CallbackContext context) => playerMovement.Jump();
        inputActions.Abilities.Teleport.performed += (InputAction.CallbackContext context) => isAiming = true;

        inputActions.Abilities.Teleport.canceled += (InputAction.CallbackContext context) =>
        {
            isAiming = false;
            abilityManager.Teleport();
        };
    }

    private void Update()
    {
        if (isAiming) 
            abilityManager.LocationIndicator();
    }
}
