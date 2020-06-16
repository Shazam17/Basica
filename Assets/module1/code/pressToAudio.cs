using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pressToAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public char letter;
    SaveLoad save;

    public bool lck = false;
    public createLevel_lvl1_3 create;
    public void onPressButton()
    {
        if (lck)
        {
            return;
        }
        save = new SaveLoad(levels.letters);
        //audioSource = GetComponent<AudioSource>();
        char targetLetter = create.targetLetter;

        if (!create.GetComponent<AudioSource>().isPlaying)
        {
            if (targetLetter == letter)
            {
                create.lockLetters();
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
                Handheld.Vibrate();
                save.AddM(letter.ToString());
                save.AddM(targetLetter.ToString());
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
