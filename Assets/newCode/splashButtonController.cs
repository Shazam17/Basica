using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashButtonController : MonoBehaviour
{
 
    public void PressOnLeftButton()
    {
        Application.OpenURL("https://docs.google.com/document/d/11lKnKN9OcwwFZGskKLIdOyLGT85NbDkqsNSfOS7d20M/edit");
    }

    public void PressOnRightButton()
    {
        PlayerPrefs.SetInt("wasAsked", 1);
        SceneManager.LoadScene("mainMenu");
    }
}
