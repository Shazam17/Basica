using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioCube : MonoBehaviour
{


    public AudioSource audioSource;
    public AudioClip clip;
    public void Start()
    {
        PlayerPrefs.SetInt("playing", 0); 
    }

    public void Play()
    {
        int playingGlobal = PlayerPrefs.GetInt("playing");
        if (!audioSource.isPlaying && playingGlobal == 0)
        {
            audioSource.Stop();
            //StartCoroutine(LockPlaying());
            audioSource.PlayOneShot(clip);
        }
     
    }
   
    public IEnumerator LockPlaying()
    {
        PlayerPrefs.SetInt("playing", 1);
        yield return new WaitForSeconds(1);
        PlayerPrefs.SetInt("playing", 0);

    }

}
