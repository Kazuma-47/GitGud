using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 sensitivity;
    private float verticalRotation = 0f;
    private CharacterController characterController;
    private float minVerticalAngle = -80f;
    private float maxVerticalAngle = 80f;
    public static CameraController Instance { get; private set; }
    private Camera camera;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
        camera = Camera.main;
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
    public void SetFOV(float newFov)
    {
        camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, newFov, 1f);
    }
}
