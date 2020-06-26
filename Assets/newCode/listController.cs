using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;




public class listController : MonoBehaviour
{

    public Transform[] contentLists;

    SaveLoad save;

    public GameObject img;
    public GameObject text;


    string selected;
    public string lettersPath = "letters/";
    public string numbersPath = "Грани для букв и цифр/";
    public string colorsPath = "Грани для букв и цифр/";
    public string figuresPath = "Грани для букв и цифр/";
    public string animals = "newDesign/НОВЫЕ ЖИВОТНЫЕ 2 УРОВЕНЬ/родители/";
    List<GameObject> spawned;

    void Start()
    {
        spawned = new List<GameObject>();
    }
    string UppercaseFirst(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }
       
        char[] a = s.ToCharArray();
        a[0] = char.ToUpper(a[0]);
        return new string(a);
    }

    public void loadStat(string level)
    {
      
        var fix = Instantiate(text);
        if (level == selected)
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
          
            foreach (var list in contentLists)
            {
                var grid = list.gameObject.GetComponent<GridLayoutGroup>();
                grid.cellSize = new Vector2(250, 70);
                grid.constraintCount = 1;
                
            }
            path = animals;
            foreach (var letter in save.letters)
            {
                Debug.Log(letter.Key);

                var go = Instantiate(text);
                spawned.Add(go);
                text.GetComponent<Text>().text = UppercaseFirst(letter.Key);

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
            return;
        }
        foreach (var list in contentLists)
        {
            var grid = list.gameObject.GetComponent<GridLayoutGroup>();
            grid.cellSize = new Vector2(100, 100);
            grid.constraintCount = 3;
        }
        Debug.Log(save.letters.Count);
        foreach (var letter in save.letters)
        {
            
            Sprite let;
            if (level == levels.letters)
            {
                let = Resources.Load<Sprite>(path + letter.Key.ToUpper());
            }
            else
            {
                let = Resources.Load<Sprite>(path + letter.Key);
            }
            if (letter.Key == "0")
            {
                continue;
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
