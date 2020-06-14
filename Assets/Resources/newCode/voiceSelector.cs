using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class voiceSelector : MonoBehaviour
{
    public string path;

    public Image maleBack;
    public Image femaleBack;


    public void Start()
    {
        path = PlayerPrefs.GetString("voicePath");


        if(path == "мужской/")
        {
            femaleBack.color = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
        }
        else
        {
            maleBack.color = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }


    public void SetMale()
    {
        PlayerPrefs.SetString("voicePath","мужской/");
        maleBack.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
        femaleBack.color = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
    }

    public void SetFemale()
    {
        PlayerPrefs.SetString("voicePath", "женский/");
        maleBack.color = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
        femaleBack.color = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
    }



}
