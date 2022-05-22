using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKodama : MonoBehaviour
{
    public GameObject kodama;
    public GameObject kodama1;
    public GameObject kodama2;

    public GameObject myObject;

    private Animator kodamaAnimator;
    
    private SpriteRenderer rend;
    private SpriteRenderer rend1;
    private SpriteRenderer rend2;    

    // Start is called before the first frame update
    void Start()
    {
        kodamaAnimator = kodama.GetComponent<Animator>();

        rend = kodama.GetComponent<SpriteRenderer>();
        rend1 = kodama1.GetComponent<SpriteRenderer>();
        rend2 = kodama2.GetComponent<SpriteRenderer>();
        
    }

    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            Color c1 = rend1.material.color;
            Color c2 = rend2.material.color;

            c.a = f;

            // FadeOut & Move
            rend.material.color = c;
            kodama.transform.position = new Vector3(kodama.transform.position.x+0.1f, kodama.transform.position.y, kodama.transform.position.z);

            // FadeOut
            rend1.material.color = c;
            rend2.material.color = c;

            yield return new WaitForSeconds(0.05f);
        }

        // Disable the GameObject once you finish the animation
        myObject.SetActive(false);        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            kodamaAnimator.SetBool("kodamaWalk", true);

            StartCoroutine("FadeOut");
        }
    }

}
