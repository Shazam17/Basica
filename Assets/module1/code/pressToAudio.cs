using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressToAudio : MonoBehaviour
{
    AudioSource aS;
    public char letter;


    public void onPressButton()
    {
        aS = GetComponent<AudioSource>();
        char targetLetter = GameObject.Find("gameManager").GetComponent<createLevel_lvl1_3>().targetLetter;
        
        if(targetLetter == letter)
        {
            AudioClip cl = OpenGteets.GetGreet();
            aS.PlayOneShot(cl);
            StartCoroutine(ToNextLevel());
        }
        else
        {
            AudioClip cl = OpenGteets.GetDis();
            aS.PlayOneShot(cl);
        }

    }


    IEnumerator ToNextLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("lettersLevel3");

    }

}
