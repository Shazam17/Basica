using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createLevel1 : MonoBehaviour
{

    public GameObject uiPart;
    
    void Start()
    {
        Sprite[] images = Resources.LoadAll<Sprite>("животные_картинки/Уровень 1");


        GetComponent<RectTransform>().sizeDelta = new Vector2(images.Length * 655, 437);

        string path = Hooks.GetVoicePath();

        foreach(var image in images){
            var go = Instantiate(uiPart, gameObject.transform);
            go.GetComponent<Image>().sprite = image;
            go.GetComponent<animalBatch>().text.text = image.name;
            AudioClip clip = Resources.Load<AudioClip>(path + "Животные/Уровень 1/" + image.name);
            go.GetComponent<animalBatch>().clip = clip; 

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
