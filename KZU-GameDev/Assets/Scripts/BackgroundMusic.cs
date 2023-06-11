using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioSource backgroundMusic;

    private void Start()
    {
        backgroundMusic.Play();
    }
 
}
