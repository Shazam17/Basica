using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class level_navigator_mainMenu : MonoBehaviour
{
    public GameObject blurBack;
    public GameObject popUp;

    public void Start()
    {
        Input.multiTouchEnabled = false;
    }

    public void ClosePopUp()
    {
        popUp.GetComponent<Animator>().Play("popUpDisApear");
        blurBack.GetComponent<Animator>().Play("BlurDisApear");

    }
    public void DisablePopUp()
    {
        blurBack.SetActive(false);
        popUp.SetActive(false);
    }

    public void Navigate(string scene)
    {
        SceneManager.LoadScene(scene);
    }

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
        blurBack.SetActive(true);
        blurBack.GetComponent<Animator>().Play("BlurApear");
        popUp.SetActive(true);
        PopUpScript popUpScript = popUp.GetComponent<PopUpScript>();
        
        popUpScript.GenetaratePopUp();
        popUpScript.scene = "settings";
    }

    public void OpenStatistics()
    {
        blurBack.SetActive(true);
        blurBack.GetComponent<Animator>().Play("BlurApear");
        popUp.SetActive(true);
        PopUpScript popUpScript = popUp.GetComponent<PopUpScript>();
        popUpScript.GenetaratePopUp();
        popUpScript.scene = "statistics";
    }

}
