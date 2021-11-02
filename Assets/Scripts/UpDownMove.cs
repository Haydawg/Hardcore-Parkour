using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2.0f;
    public float maxY = 0.0f;
    public float minY = -2.0f;
    bool isLowering = true;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float yOffest = speed * Time.deltaTime;

        if (transform.position.y >= maxY)
        {
            isLowering = true;
        }
        if (transform.position.y <= minY)
        {
            isLowering = false;
        }
        if (isLowering)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - yOffest, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + yOffest, transform.position.z);
        }
    }
}
