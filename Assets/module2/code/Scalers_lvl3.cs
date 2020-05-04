using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scalers_lvl3 : MonoBehaviour
{
    public ScalarPart_lvl3 left;
    public ScalarPart_lvl3 right;

    public GameObject image;

    AudioSource audioSource;

    public void Start()
    {
        int randNumber = Random.Range(1, 10);

        audioSource = GetComponent<AudioSource>();
        string path = Hooks.GetVoicePath();
        Sprite[] texts = Resources.LoadAll<Sprite>("numbers_images/" + randNumber.ToString());
        AudioClip clip = Resources.Load<AudioClip>(path + "Цифры/Уровень 3/конфетки/" + randNumber.ToString()) as AudioClip;
        image.GetComponent<Image>().sprite = texts[Random.Range(0,texts.Length)] as Sprite;
        right.SetWeight(randNumber);
        audioSource.PlayOneShot(clip);
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
