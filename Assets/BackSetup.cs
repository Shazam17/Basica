using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackSetup : MonoBehaviour
{
    // Start is called before the first frame update

    public Image[] images;
    void Start()
    {
        string img = PlayerPrefs.GetString("backImage");
        
        if(img.Length != 0)
        {
            Sprite targetImage = Resources.Load<Sprite>(img);
            foreach (var image in images)
            {
                image.sprite = targetImage;
            }
        }
        else
        {
            PlayerPrefs.SetString("backImage","зима");
            Sprite targetImage = Resources.Load<Sprite>("зима");
            foreach (var image in images)
            {
                image.sprite = targetImage;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
