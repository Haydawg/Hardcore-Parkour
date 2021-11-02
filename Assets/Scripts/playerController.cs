using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform playerCamera = null;

    [SerializeField]
    float mouseSensitiviey = 3.5f;

    [SerializeField]
    float walkSpeed = 10f;
    [SerializeField]
    float jumpheight = 300f;

    [SerializeField]
    float disToGround = 0.0f;

    [SerializeField]
    bool lockCursor = true;

    float cameraPitch = 0.0f;
    float horizontalMovement;
    float verticleMovement;
    Vector3 moveDirection;
    Rigidbody rb;
    bool Grounded;

    void Start()
    {
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();
        Grounded = isGrounded();
        Debug.Log(Grounded);
        MovePlayer();
        if (Grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(0, jumpheight, 0);
            }
        }
    }
    void UpdateMouseLook()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitiviey);

        cameraPitch -= mouseDelta.y * mouseSensitiviey;

        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;
    }
    void UpdateMovement()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticleMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticleMovement + transform.right * horizontalMovement;

        moveDirection.Normalize();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        rb.AddForce(moveDirection * walkSpeed, ForceMode.Acceleration);
    }
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, disToGround + 0.1f);
    }
    
}
