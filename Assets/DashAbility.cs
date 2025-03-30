using System.Collections;
using UnityEngine;

public class DashAbility : Ability
{
    [SerializeField] private float dashSpeed;

    private CharacterController characterController;
    private Vector3 dashDirection;
    private float dashDuration = 0.5f;
    private float elapsedTime;

    private void Start() => characterController = GetComponent<CharacterController>();

    public override void OnActivate() => base.OnActivate();

    public override void UseAbility()
    {
        StartCoroutine(PerformDash());
        StartCoolDown();
    }
    public IEnumerator PerformDash()
    {
        if (!abilityReady)
            yield break;
        dashDirection = Camera.main.transform.forward;
        dashDirection.y = 0f;
        dashDirection.Normalize();

        while (elapsedTime < dashDuration)
        {
            characterController.Move(dashDirection * dashSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            CameraController.Instance.SetFOV(70f);
            yield return null;
        }
        elapsedTime = 0;
        CameraController.Instance.SetFOV(60f);
    } 
}
