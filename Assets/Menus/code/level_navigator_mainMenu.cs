using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_navigator_mainMenu : MonoBehaviour
{
    public void OpenLetterSubMenu()
    {
        SceneManager.LoadScene("subMenuTemplate");
        PlayerPrefs.SetString("SubMenuType", "буквы");
        PlayerPrefs.SetFloat("subMenuPos", 0.0f);
    }

    public void OpenNumbersSubMenu()
    {
        SceneManager.LoadScene("subMenuTemplate");
        PlayerPrefs.SetString("SubMenuType", "цифры");
        PlayerPrefs.SetFloat("subMenuPos", 0.0f);
    }

    public void OpenColorsSubMenu()
    {
        SceneManager.LoadScene("subMenuTemplate");
        PlayerPrefs.SetString("SubMenuType", "цвета");
        PlayerPrefs.SetFloat("subMenuPos", 0.0f);
    }

    public void OpenFiguresSubMenu()
    {
        SceneManager.LoadScene("subMenuTemplate");
        PlayerPrefs.SetString("SubMenuType", "фигуры");
        PlayerPrefs.SetFloat("subMenuPos", 0.0f);
    }

    public void OpenAnimalsSubMenu()
    {
        SceneManager.LoadScene("subMenuTemplate");
        PlayerPrefs.SetString("SubMenuType", "животные");
        PlayerPrefs.SetFloat("subMenuPos", 0.0f);
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("settings");
    }

    public void OpenStatistics()
    {
        SceneManager.LoadScene("statistics");
    }

}
