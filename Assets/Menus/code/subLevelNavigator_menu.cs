using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class subLevelNavigator_menu : MonoBehaviour
{ 
    public Image backLeft;
    public Image backRight;
    public Image mainImage;
    public GameObject menuObject3;

    ModuleStrategy subMenuStrategy;


    void SetBackground()
    {

    }

    void Start()
    {
        string subLevelType = PlayerPrefs.GetString("SubMenuType");
        
        switch (subLevelType)
        {
            case "буквы":
                subMenuStrategy = new LettersStrategy();
                break;
            case "цифры":
                subMenuStrategy = new NumbersStrategy();
                break;
            case "цвета":
                subMenuStrategy = new ColorsStrategy();
                break;
            case "фигуры":
                subMenuStrategy = new FiguresStrategy();
                break;
            case "животные":
                menuObject3.SetActive(false);
                subMenuStrategy = new AnimalsStrategy();
                break;

            default:
                Debug.Log("undefined behavior");
                break;
        }
        Sprite left = Resources.Load<Sprite>("newDesign/subMenuImages/" + subLevelType + "Лево");
        Sprite right = Resources.Load<Sprite>("newDesign/subMenuImages/" + subLevelType + "Право");

        backLeft.sprite = left;
        backRight.sprite = right;

        Sprite mainImageSprite = Resources.Load<Sprite>("newDesign/заголовки/" + subLevelType);
        Debug.Log("newDesign/заголовки/" + subLevelType);
        mainImage.sprite = mainImageSprite;
      
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
