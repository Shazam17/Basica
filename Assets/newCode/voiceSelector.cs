using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class voiceSelector : MonoBehaviour
{

    public AudioSource audioSource;
    public string path;

    public Button maleBack;
    public Button femaleBack;


    public void Start()
    {
        path = PlayerPrefs.GetString("voicePath");

       
        
        if(path == "мужской/")
        {
            maleBack.Select();
        }
        else
        {
            femaleBack.Select();
        }
    }


    public void SetMale()
    {
        audioSource.PlayOneShot(audioSource.clip);
        PlayerPrefs.SetString("voicePath","мужской/");
        maleBack.Select();
    }

    public void SetFemale()
    {
        audioSource.PlayOneShot(audioSource.clip);
        PlayerPrefs.SetString("voicePath", "женский/");
        femaleBack.Select();
    }

}




