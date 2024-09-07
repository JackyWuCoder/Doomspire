using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 700.0f;
    private Rigidbody rb;
    private float moveX;
    private float moveZ;
    private float mouseX;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void GetInput()
    {
        // A-D keys for left-right movement
        moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        // W-S keys for forward-backward movement
        moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        // Mouse X-axis input for rotation around Y-axis
        mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
    }

    private void MovePlayer()
    {
        Vector3 movement = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(transform.position + movement);
    }

    private void RotatePlayer()
    {
        Quaternion targetRotation = Quaternion.Euler(0, rb.rotation.eulerAngles.y + mouseX, 0);
        rb.MoveRotation(targetRotation);
    }
}
