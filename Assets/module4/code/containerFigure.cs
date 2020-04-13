using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class containerFigure : MonoBehaviour
{
    public string type;
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(type == other.GetComponent<dragFigure>().type)
        {
            OpenGteets.OpenGreetingScene();
        }
    }
 
}
