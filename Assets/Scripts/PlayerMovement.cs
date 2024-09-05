using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 700.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        RotatePlayer();
    }

    private void MovePlayer()
    {
        // A-D keys for left-right movement
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        // W-S keys for forward-backward movement
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        
        Vector3 movement = transform.right * moveX + transform.forward * moveY;
        rb.MovePosition(transform.position + movement);
    }

    private void RotatePlayer()
    {
        // Mouse X-axis input for rotation around Y-axis
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, mouseX, 0);
    }
}
