using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSound : MonoBehaviour
{
    public GameObject kodamaSong;
    PlaySound ks;
    

    // Start is called before the first frame update
    void Start()
    {
        // Call the Script inside the GameObject
        ks = kodamaSong.GetComponent<PlaySound>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fadeSound()
    {
        while(ks.audio.volume > 0.01f)
        {
            ks.audio.volume -= Time.deltaTime / 1.0f;
            yield return null;
        }

        ks.audio.volume = 0;
        ks.audio.Stop();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //ks.audio.Stop();
            StartCoroutine("fadeSound");
        }
    }
}
