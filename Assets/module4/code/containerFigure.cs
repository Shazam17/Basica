using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class containerFigure : MonoBehaviour
{
    public string type;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        dragFigure fig = other.GetComponent<dragFigure>();
        if (type == fig.type)
        {
            if(!fig.isActive && !audioSource.isPlaying)
            {
                Hooks.GetInstance().ToNewLevel("figuresLevel2", audioSource);
                fig.StopAct();
        
            }
        }
        else
        {
            if (!fig.isActive && !audioSource.isPlaying)
            {
                Hooks.GetInstance().PlayDis(audioSource);
                fig.StopAct();
            }
        }
    }

}
