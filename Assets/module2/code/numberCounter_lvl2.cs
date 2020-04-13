using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class numberCounter_lvl2 : MonoBehaviour
{

    public int counter = 0;
    public int targerCount = 3;

    public void EndLevel()
    {
        if(counter == targerCount)
        {
            OpenGteets.OpenGreetingScene();
            Debug.Log("okk");
        }
        else
        {
            Debug.Log("not okk");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        counter++;
        Debug.Log("letter match!!");
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        counter--;
        Debug.Log("letter goes");
    }


}
