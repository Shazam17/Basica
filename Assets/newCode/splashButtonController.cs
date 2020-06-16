using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashButtonController : MonoBehaviour
{
 
    public void PressOnLeftButton()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.ParaLion.BasicaOffworld&hl=ru");
    }

    public void PressOnRightButton()
    {
        PlayerPrefs.SetInt("wasAsked", 1);
        SceneManager.LoadScene("mainMenu");
    }
}
