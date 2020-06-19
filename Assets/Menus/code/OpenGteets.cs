using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGteets : MonoBehaviour
{

    private string path;
    // Start is called before the first frame update
    void Start()
    {
        path = PlayerPrefs.GetString(playIntro.voicePath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static AudioClip GetGreet()
    {
        string path = PlayerPrefs.GetString(playIntro.voicePath);
        AudioClip[] txt = Resources.LoadAll<AudioClip>(path + "greets/");

        AudioClip clip = txt[Random.Range(0, txt.Length)] as AudioClip;

        return clip;

    }
    public static AudioClip GetDis()
    {
        string path = PlayerPrefs.GetString(playIntro.voicePath);
        AudioClip[] txt = Resources.LoadAll<AudioClip>(path + "disRespect/");

        AudioClip clip = txt[Random.Range(0, txt.Length)] as AudioClip;

        return clip;

    }
    public static void OpenGreetingScene()
    {
        SceneManager.LoadScene("LevelCompleteDebug");
    }
}
