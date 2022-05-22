using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{    
    public AudioSource audio;

    public bool alreadyPlayed = false;  

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!alreadyPlayed)
            {
                // Play Kodama.wav song
                audio.Play();
                alreadyPlayed = true;
            }
        }
    }
}
