﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class listController : MonoBehaviour
{

    public Transform[] contentLists;

    SaveLoad save;

    public GameObject img;


    string selected;
    public string lettersPath = "letters/";
    public string numbersPath = "Грани для букв и цифр/";
    public string colorsPath = "Грани для букв и цифр/";
    public string figuresPath = "Грани для букв и цифр/";
    public string animals = "Грани для букв и цифр/";
    List<GameObject> spawned;

    void Start()
    {
        spawned = new List<GameObject>();
    }

    public void loadStat(string level)
    {
        if(level == selected)
        {
            return;
        }
        selected = level;
        foreach(var go in spawned)
        {
            Destroy(go);
        }
        spawned.Clear();
        save = new SaveLoad(level);

        string path = "";
        if (level == levels.letters)
        {
            path = lettersPath;
        }
        if (level == levels.numbers)
        {
            path = numbersPath;
        }
        if (level == levels.colors)
        {
            path = colorsPath;
        }
        if (level == levels.figures)
        {
            path = figuresPath;
        }
        if (level == levels.animals)
        {
            path = animals;
        }
        foreach (var letter in save.letters)
        {
           
            Debug.Log(letter.Key);
            Debug.Log(letter.Value.toNumber().ToString());
            Sprite let;
            if (level == levels.letters)
            {
                let = Resources.Load<Sprite>(path + letter.Key.ToUpper());
            }
            else
            {
                let = Resources.Load<Sprite>(path + letter.Key);
            }

            var go = Instantiate(img);
            spawned.Add(go);
            go.GetComponent<Image>().sprite = let;

            if (letter.Value.toNumber() < 0.4)
            {
                go.transform.SetParent(contentLists[0]);
            }
            if (letter.Value.toNumber() > 0.4 && letter.Value.toNumber() < 0.7)
            {
                go.transform.SetParent(contentLists[1]);

            }
            if (letter.Value.toNumber() > 0.7)
            {
                go.transform.SetParent(contentLists[2]);

            }
        }
    }



}
