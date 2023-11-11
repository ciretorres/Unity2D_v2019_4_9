using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Application.LoadLevel("HUD");
        SceneManager.LoadScene("HUD 1");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
