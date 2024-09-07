using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float mouseSensitivity = 1.0f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 0.5f;

    private CharacterController controller;
    private float yRotation;
    private float yVelocity;

    // User input
    private float moveX;
    private float moveZ;
    private float mouseX;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        // Lock cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
        RotatePlayer();
        JumpPlayer();
    }

    private void GetInput()
    {
        // A-D keys for left-right movement
        moveX = Input.GetAxis("Horizontal");
        // W-S keys for forward-backward movement
        moveZ = Input.GetAxis("Vertical");
        // Mouse X-axis input for rotation around Y-axis
        mouseX = Input.GetAxis("Mouse X");
        // If space key was pressed then jumping is true
        isJumping = Input.GetButtonDown("Jump");
    }

    private void MovePlayer()
    {
        // Movement direction in player's local space
        Vector3 moveDirection = new Vector3(moveX , yVelocity, moveZ);
        // Converts movement direction from local space to world space
        moveDirection = transform.TransformDirection(moveDirection);
        // Apply movement to player in world space
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        // Player's rotation increment along the y-axis
        yRotation += mouseX * mouseSensitivity;
        // Apply y-axis rotation to player in local space
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void JumpPlayer()
    {
        if (controller.isGrounded)
        {
            /* When player is already on the ground we set the y velocity to 0 in order to 
                prevent the player from gaining increasingly negative velocity. */
            yVelocity = 0;
            if(isJumping)
            {
                /* Derived from kinematic equation that calculates the required initial vertical velocity
                    to ensure the player reaches the jumpHeight (final velocity is 0) before gravity
                    pull the player back down. */
                yVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        // Gravity is consistently being applied to the player
        yVelocity += gravity * Time.deltaTime;
    }
}
