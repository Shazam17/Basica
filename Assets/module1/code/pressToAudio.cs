using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressToAudio : MonoBehaviour
{
    AudioSource audioSource;
    public char letter;
    SaveLoad save;

    public void onPressButton()
    {
        save = new SaveLoad(levels.letters);
        audioSource = GetComponent<AudioSource>();
        char targetLetter = GameObject.Find("gameManager").GetComponent<createLevel_lvl1_3>().targetLetter;

        if (!GameObject.Find("gameManager").GetComponent<AudioSource>().isPlaying)
        {
            if (targetLetter == letter)
            {
                save.AddP(letter.ToString());
                AudioClip cl = OpenGteets.GetGreet();
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(cl);
                }

                StartCoroutine(ToNextLevel());
            }
            else
            {
                save.AddM(letter.ToString());
                AudioClip cl = OpenGteets.GetDis();
                if (!audioSource.isPlaying)
                {
                    audioSource.PlayOneShot(cl);
                }
            }
        }
      

    }


    IEnumerator ToNextLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("lettersLevel3");

    }

}
