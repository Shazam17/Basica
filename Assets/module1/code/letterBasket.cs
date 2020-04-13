using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class letterBasket : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        OpenGteets.OpenGreetingScene();
        Debug.Log("letter match!!");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("letter goes");
    }
   
}
