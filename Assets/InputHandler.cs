using UnityEngine;
using UnityEngine.InputSystem;


public class InputHandler : MonoBehaviour
{
    [SerializeField] public Controls inputActions;
    private PlayerMovement playerMovement;
    private AbilityManager abilityManager;
    private CameraController cameraController;
    private bool teleportActive;
    private bool phaseAcive;
    private void Start()
    {
        inputActions = new Controls();
        inputActions.PlayerMovement.Enable();
        inputActions.Abilities.Enable();
        playerMovement = GetComponent<PlayerMovement>();
        abilityManager = GetComponent<AbilityManager>();
        cameraController = GetComponent<CameraController>();
    }

    private void FixedUpdate()
    {
        Vector2 movementInput = inputActions.PlayerMovement.Movement.ReadValue<Vector2>();
        playerMovement.MovePlayer(movementInput);

        inputActions.PlayerMovement.Jump.performed += (InputAction.CallbackContext context) => playerMovement.Jump();
        inputActions.Abilities.Teleport.performed += (InputAction.CallbackContext context) => teleportActive = true;
        inputActions.Abilities.Dash.performed += (InputAction.CallbackContext context) => abilityManager.ActivateAbility(2);
        inputActions.Abilities.Phase.performed += (InputAction.CallbackContext context) => phaseAcive = true;

        inputActions.Abilities.Phase.canceled += (InputAction.CallbackContext context) =>
        {
            phaseAcive = false;
            abilityManager.UseAbility(3);
        };
        inputActions.Abilities.Teleport.canceled += (InputAction.CallbackContext context) =>
        {
            teleportActive = false;
            abilityManager.UseAbility(1);
        };
    }

    private void Update()
    {
        Vector2 mouseInput = inputActions.PlayerMovement.Look.ReadValue<Vector2>();
        cameraController.Look(mouseInput);

        if (teleportActive) 
            abilityManager.ActivateAbility(1);
        if (phaseAcive)
            abilityManager.ActivateAbility(3);
    }
}
