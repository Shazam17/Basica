using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel_lvl3 : MonoBehaviour
{

    public container_figure_lvl3[] figures;
   
    public void OnPressButton()
    {
        bool matched = true;
        foreach(var figure in figures)
        {
            if (!figure.matched)
            {
                matched = false;
                break;
            }
        }

        if (matched)
        {
            OpenGteets.OpenGreetingScene();
        }
    }
}
