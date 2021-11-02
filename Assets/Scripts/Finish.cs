using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject finishtext;
    public GameObject trophy;
    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        finishtext.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void WIN()
    {
        if (!audio.isPlaying)
            {
                audio.Play(0);
            }
        finishtext.SetActive(true);
    }
}
