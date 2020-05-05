using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scalers_lvl3 : MonoBehaviour
{
    public ScalarPart_lvl3 left;
    public ScalarPart_lvl3 right;

    public GameObject image;

    public Image selfImage;

    public Sprite lowerImage;
    public Sprite upperImage;
    public Sprite eqImage;

    AudioSource audioSource;

    public int _delta = 0;

    public void SetDelta(int number)
    {
        if (number == 0 )
        {
            selfImage.sprite = eqImage;
        }
        if (number < 0)
        {
            selfImage.sprite = lowerImage;
        }
        if (number > 0)
        {
            selfImage.sprite = upperImage;
        }
        _delta = number;
    }

    public void PlusDelta(int number)
    {
        SetDelta(_delta + number);
    }

    public void Start()
    {
        int randNumber = Random.Range(1, 10);
        SetDelta(randNumber);


        audioSource = GetComponent<AudioSource>();
        string path = Hooks.GetVoicePath();
        Sprite[] texts = Resources.LoadAll<Sprite>("numbers_images/" + randNumber.ToString());
        AudioClip clip = Resources.Load<AudioClip>(path + "Цифры/Уровень 3/конфетки/" + randNumber.ToString());
        image.GetComponent<Image>().sprite = texts[Random.Range(0,texts.Length)];
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
