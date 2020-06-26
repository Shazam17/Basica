using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSubMenuButton : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        RectTransform tr = GetComponent<RectTransform>();
    
        
    }


    public void Click()
    {
        audioSource.PlayOneShot(clip);
    }
   public void backToChoosePaint()
    {
        SceneManager.LoadScene("ColorsLevel3Choose");
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
