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


    public GreetParticle particles;

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
                particles.TurnParticleOn();
                int lvl = PlayerPrefs.GetInt("lvl1_3_letter");
                if (lvl == 31)
                {
                    PlayerPrefs.SetInt("lvl1_3_letter", 0);
                }
                else
                {
                    PlayerPrefs.SetInt("lvl1_3_letter", lvl + 1);

                }

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
                StartCoroutine(waitFalse());
            }
        }
      

    }

    public IEnumerator waitFalse()
    {
        if (!audioSource.isPlaying)
        {
            string path = Hooks.GetVoicePath();
            var letterClip = Resources.Load<AudioClip>(path + "Буквы/Уровень 1/буква " + letter);
         
            audioSource.PlayOneShot(letterClip);


            while (audioSource.isPlaying)
            {
                yield return new WaitForSeconds(0.001f);
            }
            create.PlayTaskAgain();
        }
    }


    IEnumerator ToNextLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("lettersLevel3");

    }

}
