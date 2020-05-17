using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioCube : MonoBehaviour
{


    AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
     
    }
   

}
