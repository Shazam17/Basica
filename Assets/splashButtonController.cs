using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splashButtonController : MonoBehaviour
{
 


    public void PressOnRightButton()
    {
        PlayerPrefs.SetInt("wasAsked", 1);
        SceneManager.LoadScene("mainMenu");
    }
}
