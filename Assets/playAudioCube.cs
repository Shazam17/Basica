using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioCube : MonoBehaviour
{


    AudioSource aS;

    public void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    public void Play()
    {
        aS.PlayOneShot(aS.clip);
    }
   

}
