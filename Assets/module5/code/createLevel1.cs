﻿using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createLevel1 : MonoBehaviour
{

    public GameObject uiPart;
    private AudioSource audioSource;

    public Button firstButton;
    public List<GameObject> spawned;
    public selectAnimalGroup selector;

    List<List<Sprite>> sprites;
    string path;

    Vector2 initPlace;

    void Start()
    {
        initPlace = transform.GetComponent<RectTransform>().anchoredPosition;
        sprites = new List<List<Sprite>>();
        Sprite[] images1 = Resources.LoadAll<Sprite>("животные_картинки/Уровень 1/домашние/");
        Sprite[] images2 = Resources.LoadAll<Sprite>("животные_картинки/Уровень 1/лесные/");
        Sprite[] images3 = Resources.LoadAll<Sprite>("животные_картинки/Уровень 1/тропические/");
        sprites.Add(new List<Sprite>(images1));
        sprites.Add(new List<Sprite>(images2));
        sprites.Add(new List<Sprite>(images3));


        path = Hooks.GetVoicePath();
        audioSource = GetComponent<AudioSource>();
        GetComponent<playProlog>().PlayProlog();

        LoadAnimals(0);
        firstButton.Select();
    }

    int selected = -1;

    public void LoadAnimals(int val)
    {
        selector.Select(val);
        GetComponent<RectTransform>().anchoredPosition = initPlace;
        if(selected == val)
        {
            return;
        }
        
        foreach(var spwnd in spawned)
        {
            Destroy(spwnd);
        }
        spawned.Clear();

        foreach (var image in sprites[val])
        {
            var go = Instantiate(uiPart, gameObject.transform);
            go.GetComponent<Image>().sprite = image;
            spawned.Add(go);
            animalBatch batch = go.GetComponent<animalBatch>();
            if(selected == -1)
            {
                StartCoroutine(batch.lockProlog());
            }
            AudioClip ch = Resources.Load<AudioClip>(path + "Животные/Уровень 1/" + image.name + "1");
            AudioClip animalSound = Resources.Load<AudioClip>(path + "Животные/Уровень 2 Звуки/" + image.name);

            batch.clip = animalSound;
            batch.ch = ch;
            batch.audioSource = audioSource;

        }
        selected = val;
    }


}
