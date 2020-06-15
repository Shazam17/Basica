using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statisticsSelector : MonoBehaviour
{
    public Image[] backHeaders;

    public listController controller;

    public int selected;
    public string selectedLevel;


    public void SelectLevel(int level)
    {
        foreach(var image in backHeaders)
        {
            image.color = new Vector4(0f, 0f, 0f, 0f);
        }
        backHeaders[level].color = new Vector4(1f, 1f, 1f, 1f);
        controller.loadStat(backHeaders[level].gameObject.name);
    }

  
    void Start()
    {
        SelectLevel(0);
    }

    
}
