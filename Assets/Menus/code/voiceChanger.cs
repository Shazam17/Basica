using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiceChanger : MonoBehaviour
{


    public void SetMaleVoice()
    {
        PlayerPrefs.SetString("voicePath", "мужской/");
    }

    public void SetFemaleVoice()
    {
        PlayerPrefs.SetString("voicePath", "женский/");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
