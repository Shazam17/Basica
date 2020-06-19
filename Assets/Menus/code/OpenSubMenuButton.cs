using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSubMenuButton : MonoBehaviour
{

    void Start()
    {
        RectTransform tr = GetComponent<RectTransform>();
    
        
    }

   

    public IEnumerator backToMenuAsync()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("mainMenu");
    }

    public IEnumerator backToSubMenuAsync()
    {
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("subMenuTemplate");
    }


    public void BackToSubMenu()
    {
        StartCoroutine(backToSubMenuAsync());
    }
    public void BackToMainMenu()
    {
        StartCoroutine(backToMenuAsync());
    }
}
