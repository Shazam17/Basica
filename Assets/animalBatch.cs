using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class animalBatch : MonoBehaviour
{

    public Text text;
    public AudioClip clip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(clip);
        }
    }    
  
}
