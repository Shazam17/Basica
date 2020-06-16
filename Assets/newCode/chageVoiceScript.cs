using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chageVoiceScript : MonoBehaviour
{

    Toggle[] comps;
    public void SetMaleVoice()
    {
        PlayerPrefs.SetString("voicePath", "мужской/");
    }

    public void SetFemaleVoice()
    {
        PlayerPrefs.SetString("voicePath", "женский/");
    }

    public void OnValueChangeM(bool on)
    {
        if (on)
        {
            foreach (var comp in comps)
            {
                comp.GetComponent<Image>().color = Color.white;
            }
            comps[0].GetComponent<Image>().color = Color.grey;
            SetMaleVoice();
        }
    }


    public void OnValueChangeF(bool on)
    {
        if (on)
        {
            foreach (var comp in comps)
            {
                comp.GetComponent<Image>().color = Color.white;
            }
            comps[1].GetComponent<Image>().color = Color.grey;
            SetFemaleVoice();
        }
    }

    void Start()
    {
        var path = PlayerPrefs.GetString("voicePath");
        comps = GetComponentsInChildren<Toggle>();
       
        Debug.Log(comps.Length);
        Debug.Log(path);

        if (path.Equals("мужской/")){
            comps[0].GetComponent<Image>().color = Color.grey;
        }
        else
        {
            comps[1].GetComponent<Image>().color = Color.grey;
        }

    }

}
