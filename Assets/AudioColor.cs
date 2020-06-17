using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioColor : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;



    public void Play()
    {
        var can = PlayerPrefs.GetInt("canTouch");
        if(can == 1 && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(clip);
        }
    }
    
}
