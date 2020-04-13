using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class subLevelNavigator_menu : MonoBehaviour
{
    public GameObject content;
    ModuleStrategy subMenuStrategy;
    // Start is called before the first frame update
    void Start()
    {
        string subLevelType = PlayerPrefs.GetString("SubMenuType");
        
        switch (subLevelType)
        {
            case "letterSubMenu":
                subMenuStrategy = new LettersStrategy();
                break;
            case "numbersSubMenu":
                subMenuStrategy = new NumbersStrategy();
                break;
            case "colorsSubMenu":
                subMenuStrategy = new ColorsStrategy();
                break;
            case "figuresSubMenu":
                subMenuStrategy = new FiguresStrategy();
                break;
            case "animalsSubMenu":

                Vector2 prevSize = content.GetComponent<RectTransform>().sizeDelta;
                content.GetComponent<RectTransform>().sizeDelta = new Vector2(prevSize.x * 2/3,prevSize.y);
                GameObject.Find("Block 3").SetActive(false);
                subMenuStrategy = new AnimalsStrategy();
                break;

            default:
                Debug.Log("undefined behavior");
                break;
        }
    }
    
    public void OpenMainMenu()
    {
        SceneManager.LoadScene("mainMenu");
    }

    public void OpenLevel1()
    {
        subMenuStrategy.LoadLevel1();
    }
    public void OpenLevel2()
    {
        subMenuStrategy.LoadLevel2();
    }
    public void OpenLevel3()
    {
        subMenuStrategy.LoadLevel3();
    }
}
