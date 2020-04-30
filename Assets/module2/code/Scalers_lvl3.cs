using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scalers_lvl3 : MonoBehaviour
{
    public ScalarPart_lvl3 left;
    public ScalarPart_lvl3 right;

    public GameObject image;



    public void Start()
    {
        int randNumber = Random.Range(1, 10);

        Object[] texts = Resources.LoadAll("numbers_images/" + randNumber.ToString(), typeof(Sprite));
        image.GetComponent<Image>().sprite = texts[Random.Range(0,texts.Length)] as Sprite;
        right.SetWeight(randNumber);
       

    }

    public bool scale()
    {
        if(left.loadedWeight == right.loadedWeight)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
