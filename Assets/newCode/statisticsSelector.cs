using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statisticsSelector : MonoBehaviour
{
    public Image[] backHeaders;
    public AudioSource audioSource;
    public listController controller;

    public int selected;
    public string selectedLevel;


    public void SelectLevel(int level)
    {
        audioSource.PlayOneShot(audioSource.clip);  
        foreach (var image in backHeaders)
        {
            image.color = new Vector4(0f, 0f, 0f, 0f);
        }
        backHeaders[level].color = new Vector4(1f, 1f, 1f, 1f);
        controller.loadStat(backHeaders[level].gameObject.name);
    }

  
    void Start()
    {
        foreach(var image in backHeaders)
        {
            image.color = new Vector4(0f, 0f, 0f, 0f);
        }
        backHeaders[0].color = new Vector4(1f, 1f, 1f, 1f);
        controller.loadStat(backHeaders[0].gameObject.name);
    }

    
}
