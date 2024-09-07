using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float mouseSensitivity = 1.0f;
    private CharacterController controller;
    private float yRotation;

    // User input
    private float moveX;
    private float moveZ;
    private float mouseX;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        MovePlayer();
        RotatePlayer();
    }

    private void GetInput()
    {
        // A-D keys for left-right movement
        moveX = Input.GetAxis("Horizontal");
        // W-S keys for forward-backward movement
        moveZ = Input.GetAxis("Vertical");
        // Mouse X-axis input for rotation around Y-axis
        mouseX = Input.GetAxis("Mouse X");
    }

    private void MovePlayer()
    {
        // Movement direction in player's local space
        Vector3 moveDirection = new Vector3(moveX , 0, moveZ);
        // Converts movement direction from local space to world space
        moveDirection = transform.TransformDirection(moveDirection);
        // Apply movement to player in world space
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    private void RotatePlayer()
    {
        // Player's rotation increment along the y-axis
        yRotation += mouseX * mouseSensitivity;
        // Apply rotation to player in local space
        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
    }
}
