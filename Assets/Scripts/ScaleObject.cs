using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{
    public float speed = 2.0f;
    private float maxSize = 2.0f;
    private float minSize = 0.2f;
    private bool isShrinking = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scaleOffset = speed * Time.deltaTime;

        if(transform.localScale.x <= minSize)
        {
            isShrinking = false;
        }
        if(transform.localScale.x >= maxSize)
        {
            isShrinking = true;
        }
        if (isShrinking)
        {
            transform.localScale = new Vector3(transform.localScale.x - scaleOffset, transform.localScale.y - scaleOffset, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x + scaleOffset, transform.localScale.y + scaleOffset, transform.localScale.z);
        }
    }
}
