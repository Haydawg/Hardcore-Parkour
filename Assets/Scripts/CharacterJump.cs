using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour
{
    public int jumpforce;
    public Rigidbody Rb;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void jump()
    {
        Rb.AddForce(0, jumpforce, 0);
    }
}
