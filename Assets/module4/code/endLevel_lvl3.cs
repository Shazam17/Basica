using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel_lvl3 : MonoBehaviour
{

    public dragFigure[] figures;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPressButton()
    {
        bool matched = true;
        foreach(var figure in figures)
        {
            if (figure.enbld)
            {
                matched = false;
                

            }
        }

        if (matched)
        {
            StartCoroutine(Hooks.GetInstance().ToNewLevel("figuresLevel3", audioSource));
        }
        else
        {
            Hooks.GetInstance().PlayDis(audioSource);
        }
    }
}
