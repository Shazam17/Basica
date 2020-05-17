using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endLevel_lvl2 : MonoBehaviour
{
    public ColorReciever_lvl2[] recievers;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
   
    public void OnButtonPress()
    {
        SaveLoad save = new SaveLoad(levels.colors);
        bool flag = true;
        foreach(var elem in recievers)
        {
            if (!elem.matched)
            {
                flag = false;
                save.AddP(elem.color);
            }
            else
            {
                save.AddM(elem.color);
            }
        }

        if (flag)
        {
          
            StartCoroutine(Hooks.GetInstance().ToNewLevel("colorsLevel2", audioSource));
        }
        else
        {
           

            Hooks.GetInstance().PlayDis(audioSource);
        }
        
    }

 
}
