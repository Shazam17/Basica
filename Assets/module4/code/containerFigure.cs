using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class containerFigure : MonoBehaviour
{
    public string type;
    public void OnTriggerEnter2D(Collider2D other)
    {

        dragFigure fig = other.GetComponent<dragFigure>();

        var aS = GetComponent<AudioSource>();

        if (type == fig.type)
        {
            if(!fig.isActive && !aS.isPlaying)
            {
                var clip = OpenGteets.GetGreet();
                aS.PlayOneShot(clip);
                fig.StopAct();
                StartCoroutine(ToNextLevel());
            }
        }
        else
        {
            if (!fig.isActive && !aS.isPlaying)
            {
                var clip = OpenGteets.GetDis();
                aS.PlayOneShot(clip);
                fig.StopAct();
            }
        }
    }

    IEnumerator ToNextLevel()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("figuresLevel2");

    }

}
