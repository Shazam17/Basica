using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createLevel_lvl1_3 : MonoBehaviour
{

    public GameObject letterPrefab;
    public GameObject parent;

    private string path;

    public char targetLetter;

    void CreateLevel()
    {
        int lvl = PlayerPrefs.GetInt("lvl1_3_letter");
        if (lvl == 0)
        {
            PlayerPrefs.SetInt("lvl1_3_letter", 1);
            lvl = 1;
        }
        else if (lvl == 31)
        {
            PlayerPrefs.GetInt("lvl1_3_letter", 1);
        }
        else
        {
            PlayerPrefs.SetInt("lvl1_3_letter", lvl + 1);

        }

        path = Hooks.GetVoicePath();

        //chooseLetter to find

        var vRand = Random.insideUnitCircle  * new Vector2(300,50);
  
        GameObject letter = Instantiate(letterPrefab, parent.transform);
        letter.GetComponent<RectTransform>().anchoredPosition = vRand;
        

        char let = letterBasket.GetRandomLetter();
        targetLetter = let;
        letter.GetComponent<pressToAudio>().letter = let;

        string del = " ";
        if (path == "мужской/"){
            del = "";
        }

        AudioClip txt = Resources.Load<AudioClip>(path + "lvl1_3_introSounds/найди.." + del  +  "с буквой " + let.ToString());

        Debug.Log(path + "lvl1_3_introSounds/найди.. с буквой " + let.ToString());

        GetComponent<AudioSource>().clip = txt;
        GetComponent<AudioSource>().PlayOneShot(txt);

        Debug.Log("letters/" + let);
        Sprite texture = Resources.Load<Sprite>("letters/" + let.ToString().ToUpper());
        letter.GetComponent<Image>().sprite = texture;



        Vector2 last = new Vector2(-350, -100);
        for (int i = 0; i < 4; i++)
        {
          
            vRand = last  + new Vector2(100,0) + Random.Range(0.1f,0.5f) * new Vector2(100, 0);
            last = vRand;
            GameObject tempLet = Instantiate(letterPrefab, parent.transform);
            tempLet.GetComponent<RectTransform>().anchoredPosition = vRand;
           
            char letterCharTemp = letterBasket.GetRandomLetter();
            while (letterCharTemp == let)
            {
                letterCharTemp = letterBasket.GetRandomLetter();
            }
            tempLet.GetComponent<pressToAudio>().letter = letterCharTemp;

            Sprite textureTemp = Resources.Load<Sprite>("letters/" + letterCharTemp.ToString().ToUpper()) ;

            tempLet.GetComponent<Image>().sprite = textureTemp;
        }
    }

    public void PlayTaskAgain()
    {
        AudioSource aS = GetComponent<AudioSource>();
        if (!aS.isPlaying)
        {
            aS.PlayOneShot(aS.clip);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

   
}
