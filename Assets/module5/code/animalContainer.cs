using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animalContainer : MonoBehaviour
{
    public string type;
   
    void OnTriggerEnter2D(Collider2D other)
    {
        string type = other.GetComponent<animalChild>().type;
        if(type == this.type)
        {  
            OpenGteets.OpenGreetingScene();
        }
    }
}
