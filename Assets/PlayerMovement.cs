using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkingSpeed;
    [SerializeField] private float runningSpeed;

    [SerializeField] private float jumpHeight;
    [SerializeField] private float gravity;
    
    private Vector3 velocity;
    private bool isWalking;
    private bool isGrounded;

    private CharacterController characterController;

    void Start() => characterController = GetComponent<CharacterController>();

    // Update is called once per frame
    void Update()
    {
        isGrounded = characterController.isGrounded;

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    public void MovePlayer(Vector2 direction)
    {
        Vector3 move = transform.right * direction.x + transform.forward * direction.y;
        characterController.Move(move * (isWalking ? walkingSpeed : runningSpeed) * Time.deltaTime);
    }
    public void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
}
