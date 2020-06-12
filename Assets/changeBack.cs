using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeBack : MonoBehaviour
{
    Toggle[] comps;

    public void OnValueChange(bool value)
    {
        var name = PlayerPrefs.GetString("backPath");
    }


    public void Set1(bool value)
    {
        if (value)
        {
            foreach(var comp in comps)
            {
                comp.GetComponent<Image>().color = Color.white;
            }
            comps[0].GetComponent<Image>().color = Color.grey;
            PlayerPrefs.SetString("backPath", "1");
        }
    }

    public void Set2(bool value)
    {
         if (value)
        {
            foreach (var comp in comps)
            {
                comp.GetComponent<Image>().color = Color.white;
            }
            comps[1].GetComponent<Image>().color = Color.grey;
            PlayerPrefs.SetString("backPath", "2");
        }
    }
    void Start()
    {
        var name = PlayerPrefs.GetString("backPath");
        comps = GetComponentsInChildren<Toggle>();

        Debug.Log(comps.Length);
        Debug.Log(name);

        if (name.Equals("1"))
        {
            comps[0].GetComponent<Image>().color = Color.grey;
        }
        else
        {
            comps[1].GetComponent<Image>().color = Color.grey;
        }

    }

}
