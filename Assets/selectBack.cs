using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class selectBack : MonoBehaviour
{

    public Sprite winter;
   
    void Start()
    {
        var val = PlayerPrefs.GetString("backImage");
        if (val == "осень")
        {
            GetComponent<Dropdown>().value = 1;
        }
        if (val == "лето")
        {
            GetComponent<Dropdown>().value = 2;
        }
        if (val == "весна")
        {
            GetComponent<Dropdown>().value = 3;
        }
    }

   public void onValChanged(Dropdown val)   
    {
        if(val.value == 0)
        {
            PlayerPrefs.SetString("backImage", "зима");
            
        }
        if(val.value == 1)
        {
            PlayerPrefs.SetString("backImage", "осень");
        }
        if (val.value == 2)
        {
            PlayerPrefs.SetString("backImage", "лето");
        }
        if (val.value == 3)
        {
            PlayerPrefs.SetString("backImage", "весна");
        }
    }
}
