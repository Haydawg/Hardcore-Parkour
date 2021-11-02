using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentOnCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        player.transform.parent = transform;
    }
    private void OnCollisionExit(Collision collision)
    {
        player.transform.parent = null;
    }
}
