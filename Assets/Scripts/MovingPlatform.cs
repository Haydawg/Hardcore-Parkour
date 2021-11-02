using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed = 2.0f;
    public GameObject player;
    public float minZOffset = 0.0f;
    public float maxZOffset = 10.0f;
    bool movingForward = true;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float zOffest = speed * Time.deltaTime;
        if (transform.position.z <= minZOffset)
        {
            movingForward = true;

        }
        if (transform.position.z >= maxZOffset)
        {
            movingForward = false;
        }
        if (movingForward)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + zOffest);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - zOffest);
        }
    }
}
