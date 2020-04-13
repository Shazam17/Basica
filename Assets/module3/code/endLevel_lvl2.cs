using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endLevel_lvl2 : MonoBehaviour
{
    public ColorReciever_lvl2[] recievers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool flag = true;
        foreach(var elem in recievers)
        {
            if (!elem.matched)
            {
                flag = false;
            }
        }

        if (flag)
        {
            OpenGteets.OpenGreetingScene();
            Debug.Log("level complete");
        }
    }
}
