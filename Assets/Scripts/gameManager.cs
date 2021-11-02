using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject player;
    public Camera playerCamera;
    public Camera orbitringCamera;
    public GameObject lose;
    public AudioSource audioData;
    bool delay;

    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
        playerCamera.enabled = false;
        orbitringCamera.enabled = true;
        lose.SetActive(false);
        audioData = player.GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -10.0f)
        {
            if (!delay)
            {
                lose.SetActive(true);
                StartCoroutine(Wait());
            }
        }
               
        if (orbitringCamera == null)
        {
            player.SetActive(true);
            playerCamera.enabled = true;
        }
    }
    public IEnumerator Wait()
    {
        delay = true;
        if (!audioData.isPlaying)
        {
            audioData.Play(0);
        }
        yield return new WaitForSeconds(3);
        player.transform.position = new Vector3(0, 1, 0);
        lose.SetActive(false);
        delay = false;
    }
}
