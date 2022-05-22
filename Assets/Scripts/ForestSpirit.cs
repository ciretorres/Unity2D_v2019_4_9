using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForestSpirit : MonoBehaviour
{
    public Vector2 cameraChange;
    public float smoothing;
    private CameraMovement cam;

    public AudioClip SoundToPlay;
    public float Volume;
    AudioSource audio;

    public bool alreadyPlayed = false;

    public GameObject forestSpirit;
    private Animator forestSpiritAnimator;

    public Image whiteFade;

    public GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
        audio = GetComponent<AudioSource>();
        forestSpiritAnimator = forestSpirit.GetComponent<Animator>();

        whiteFade.canvasRenderer.SetAlpha(0.0f);        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(cameraChange.x);   
    }

    void fadeIn()
    {
        whiteFade.CrossFadeAlpha(1, 3, false);
    }

    IEnumerator MoveForestSpirit()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {

            forestSpirit.transform.position = new Vector3(forestSpirit.transform.position.x - 0.1f, forestSpirit.transform.position.y, forestSpirit.transform.position.z);


            yield return new WaitForSeconds(0.05f);
        }
        forestSpiritAnimator.SetBool("ForestSpiritWalk", false);
        fadeIn();
        text.SetActive(true);

    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement moveScript = other.GetComponent<PlayerMovement>();
            moveScript.canMove = false;

            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;

            // Inicializa
            Vector3 targetPosition = new Vector3(cam.maxPosition.x, cameraChange.y, transform.position.z);

            // Asigna            
            cam.smoothing = smoothing;

            // Paso de parameter
            cam.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, cam.smoothing);

            if (!alreadyPlayed)
            {
                // Play The Encounter.wav song
                audio.PlayOneShot(SoundToPlay, Volume);
                alreadyPlayed = true;
            }

            // Move Forest Spirit
            forestSpiritAnimator.SetBool("ForestSpiritWalk", true);
            
            StartCoroutine("MoveForestSpirit");

            
        }
        
    }
}
