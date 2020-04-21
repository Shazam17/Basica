using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel_lvl3 : MonoBehaviour
{

    public dragFigure[] figures;
   
    public void OnPressButton()
    {
        bool matched = true;
        foreach(var figure in figures)
        {
            if (!figure.enabled)
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
