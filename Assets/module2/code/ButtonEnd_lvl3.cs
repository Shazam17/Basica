using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEnd_lvl3 : MonoBehaviour
{

    public Scalers_lvl3 scalers;
    
    public void End()
    {
        if (scalers.scale())
        {
            OpenGteets.OpenGreetingScene();
            Debug.Log("equal");
        }
        else
        {
            Debug.Log("nottt");
        }
    }
}
