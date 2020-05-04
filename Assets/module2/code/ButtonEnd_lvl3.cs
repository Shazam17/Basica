using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEnd_lvl3 : MonoBehaviour
{

    public Scalers_lvl3 scalers;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void End()
    {        
        if (scalers.scale())
        {
            StartCoroutine(Hooks.GetInstance().ToNewLevel("numbersLevel3", audioSource));
        }
        else
        {
            Hooks.GetInstance().PlayDis(audioSource);
        }
    }
    
}
