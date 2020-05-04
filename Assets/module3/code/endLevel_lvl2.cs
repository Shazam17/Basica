using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel_lvl2 : MonoBehaviour
{
    public ColorReciever_lvl2[] recievers;

   
    public void OnButtonPress()
    {
        var aS = GetComponent<AudioSource>();

        bool flag = true;
        foreach(var elem in recievers)
        {
            if (!elem.matched)
            {
                flag = false;
            }
        }

        if (flag)
        {
            if (!aS.isPlaying)
            {
                var clip = OpenGteets.GetGreet();
                aS.PlayOneShot(clip);
                StartCoroutine(ToNextLevel());
            }
        }
        else
        {
            if (!aS.isPlaying)
            {
                var clip = OpenGteets.GetDis();
                aS.PlayOneShot(clip);
            }
        }
    }


    IEnumerator ToNextLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("colorsLevel2");

    }
}
