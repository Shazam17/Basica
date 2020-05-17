using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEnd_lvl3 : MonoBehaviour
{

    public Scalers_lvl3 scalers;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void End()
    {
        SaveLoad save = new SaveLoad(levels.numbers);
        if (scalers.scale())
        {
            save.AddP(scalers.left.loadedWeight.ToString());
            StartCoroutine(Hooks.GetInstance().ToNewLevel("numbersLevel3", audioSource));
        }
        else
        {
            save.AddM(scalers.left.loadedWeight.ToString());
            Hooks.GetInstance().PlayDis(audioSource);
        }
    }
    
}
