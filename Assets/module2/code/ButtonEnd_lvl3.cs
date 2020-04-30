using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEnd_lvl3 : MonoBehaviour
{

    public Scalers_lvl3 scalers;

    private AudioSource aS;

    public void End()
    {
        aS = GetComponent<AudioSource>();
        if (scalers.scale())
        {
            var clip = OpenGteets.GetGreet();
            aS.PlayOneShot(clip);
            StartCoroutine(ToNextLevel());
        }
        else
        {
            var clip = OpenGteets.GetDis();
            aS.PlayOneShot(clip);

        }
    }


    IEnumerator ToNextLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("numbersLevel3");

    }
}
