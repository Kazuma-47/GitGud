using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 sensitivity;
    private float verticalRotation = 0f;
    private CharacterController characterController;
    private float minVerticalAngle = -80f;
    private float maxVerticalAngle = 80f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
    }

    public void Look(Vector2 mouseInput)
    {
        float mouseX = mouseInput.x * sensitivity.x;
        float mouseY = mouseInput.y * sensitivity.y;

        characterController.transform.Rotate(Vector3.up * mouseX);

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalAngle, maxVerticalAngle);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}
