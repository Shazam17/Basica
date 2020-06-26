using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class createLevel_lvl1_3 : MonoBehaviour
{

    public GameObject[] placeToSpawn;

    public GameObject letterPrefab;
    public GameObject parent;


    private string path;

    public char targetLetter;

    List<GameObject> letters;
    public GreetParticle particles;

    public void GenerateNewLevel()
    {
        StartCoroutine(toNewLevel());
    }

    public IEnumerator toNewLevel()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("lettersLevel3");
    }

    void CreateLevel()
    {
        Input.multiTouchEnabled = false;
        GameObject[] backs = Resources.LoadAll<GameObject>("Фоны Уровень 3/");
        var plc = Instantiate(backs[Random.Range(0, backs.Length)]);
        plc.transform.SetParent(parent.transform);
        plc.transform.SetAsFirstSibling();
        plc.transform.localScale = new Vector3(1,1,1);
        plc.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        plc.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        

      
        List<RectTransform> places = new List<RectTransform>();
        foreach (Transform child in plc.transform)
        {
            places.Add(child.GetComponent<RectTransform>());
        }
        letters = new List<GameObject>();
        int lvl = PlayerPrefs.GetInt("lvl1_3_letter");
        

        var cLEts = new List<char>();
        for (int i = 0; i < 32; i++)
        {
            char lettterChar = (char)(1072 + i);
            if (lettterChar != 'ё' && lettterChar !='ѐ')
            {
                cLEts.Add((char)(1072 + i));
            }
        }

        path = Hooks.GetVoicePath();

        string del = " ";
        if (path == "мужской/"){
            del = "";
        }
        char let = (char)(1072 + lvl);

        cLEts.Remove(let);
        targetLetter = let;
        AudioClip txt = Resources.Load<AudioClip>(path + "lvl1_3_introSounds/найди.." + del  +  "с буквой " + let.ToString());



        GetComponent<AudioSource>().clip = txt;
        GetComponent<AudioSource>().PlayOneShot(txt);


        Debug.Log(places.Count);
        for (int i = 0; i < 6; i++)
        {

            
            GameObject tempLet = Instantiate(letterPrefab, parent.transform);
            tempLet.transform.SetAsLastSibling();

            RectTransform place = places[Random.Range(0, places.Count)];
            tempLet.transform.SetParent(place.transform);
            tempLet.transform.localPosition = new Vector3(0, 0, 0);
            places.Remove(place);


            char letterCharTemp = cLEts[Random.Range(0, cLEts.Count)];
            pressToAudio prs = tempLet.GetComponent<pressToAudio>();
            prs.letter = letterCharTemp;
            prs.audioSource = GetComponent<AudioSource>();
            prs.create = this;
            prs.particles = particles;
            cLEts.Remove(letterCharTemp);


            Sprite textureTemp = Resources.Load<Sprite>("newDesign/Буквы/Уровень 3/" + letterCharTemp.ToString().ToUpper());
            tempLet.GetComponent<Image>().sprite = textureTemp;

            letters.Add(tempLet);
        }

 
      

        Sprite texture = Resources.Load<Sprite>("newDesign/Буквы/Уровень 3/" + let.ToString().ToUpper());
        var target = letters[Random.Range(0, letters.Count)].GetComponent<pressToAudio>();
        target.GetComponent<Image>().sprite = texture;
        target.letter = let;
        StartCoroutine(lockLettetsCoroutine());
    }

    public void lockLetters()
    {
        foreach(var letter in letters)
        {
            letter.GetComponent<pressToAudio>().lck = true;
        }
    }
    public void PlayTaskAgain()
    {
        AudioSource aS = GetComponent<AudioSource>();
        if (!aS.isPlaying)
        {
            aS.PlayOneShot(aS.clip);
            StartCoroutine(lockLettetsCoroutine());

        }
    }


    IEnumerator lockLettetsCoroutine()
    {
        foreach (var letter in letters)
        {
            letter.GetComponent<pressToAudio>().lck = true;
        }

        yield return new WaitForSeconds(3.0f);
        foreach (var letter in letters)
        {
            letter.GetComponent<pressToAudio>().lck = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

   
}
