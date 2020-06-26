using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectAnimalGroup : MonoBehaviour
{


    public createLevel1 level;

    Image[] listItems;
 
    public void Start()
    {
        listItems = transform.GetComponentsInChildren<Image>();
        listItems[0].color = new Vector4(1, 1, 1, 1);
    }

    public void Select(int value)
    {
        foreach(var image in listItems)
        {
            image.color = new Vector4(1, 1, 1, 0);
        }
        listItems[value].color = new Vector4(1, 1, 1, 1);
    }
}
