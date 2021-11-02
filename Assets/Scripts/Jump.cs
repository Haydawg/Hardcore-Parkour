using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField]
    float jumpheight = 300f;

    [SerializeField]
    float disToGround = 0.0f;

    Rigidbody rb;
    bool Grounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = isGrounded();
    }
    bool isGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, disToGround + 0.1f);
    }
    public void jump()
    {
        if(Grounded)
        {
            rb.AddForce(0, jumpheight, 0);
        }
    }
}
