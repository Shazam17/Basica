using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createLevel1 : MonoBehaviour
{

    public GameObject uiPart;
    private AudioSource audioSource;
    void Start()
    {
        Sprite[] images = Resources.LoadAll<Sprite>("животные_картинки/Уровень 1/");
      
        string path = Hooks.GetVoicePath();
        audioSource = GetComponent<AudioSource>();

        foreach (var image in images){
            var go = Instantiate(uiPart, gameObject.transform);
            go.GetComponent<Image>().sprite = image;
            animalBatch batch = go.GetComponent<animalBatch>();

            AudioClip ch = Resources.Load<AudioClip>(path + "Животные/Уровень 1/" + image.name + "1");
            AudioClip animalSound = Resources.Load<AudioClip>(path + "Животные/Уровень 2 Звуки/" + image.name );

            batch.clip = animalSound;
            batch.ch = ch;
            batch.audioSource = audioSource;

        }

        GetComponent<playProlog>().PlayProlog();
    }

}
