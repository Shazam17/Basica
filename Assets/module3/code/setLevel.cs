using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class setLevel : MonoBehaviour
{

    public testColliderBox[] recievers;
    public DragColor_lvl2[] items;

    public Image[] backs;
    private AudioSource audioSource;

    public  void PlayIntroAgain()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioSource.clip);
            foreach (var obj in items)
            {
                obj.StartCoroutine(obj.lockProlog());
            }
        }
    }

    public void RegenLevel()
    {
        SceneManager.LoadScene("colorsLevel2");
    }

    public void PlayIntro()
    {
        string path = Hooks.GetVoicePath();
        audioSource = GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>(path + "Цвета/Уровень 2/перетащи.. цветом");
        audioSource.PlayOneShot(clip);
        audioSource.clip = clip; 
    }


    string[] colors =
    {
        "синий",
        "белый",
        "голубой",
        "желтый",
        "зеленый",
        "коричневый",
        "красный",
        "оранжевый",
        "розовый",
        "серый",
        "фиолетвый",
        "чёрный"
    };


    void Start()
    {
        PlayIntro();
        //Sprite[] colors = Resources.LoadAll<Sprite>("корзины для цветов/");
        var colorList = new List<string>(colors);
          //var colorList = new List<Sprite>(colors);

        for(int i = 0; i < 3;i++)
        {
            var color = colorList[Random.Range(0, colorList.Count)];
            colorList.Remove(color);
            Debug.Log(color);

            var top = Resources.Load<Sprite>("коробки цвета/" + color + "1");
            var back = Resources.Load<Sprite>("коробки цвета/" + color + "2");
            var front = Resources.Load<Sprite>("коробки цвета/" + color + "3");

            recievers[i].targetColor = color;
            recievers[i].transform.GetChild(0).GetComponent<Image>().sprite = front;
            recievers[i].transform.GetChild(1).GetComponent<Image>().sprite = top;
            backs[i].GetComponent<Image>().sprite = back;
        }

        var recList = new List<testColliderBox>(recievers);
        for(int i = 0; i < items.Length; i++)
        {
            testColliderBox tRes = recList[Random.Range(0, recList.Count)];
            recList.Remove(tRes);
            Sprite[] colorItems = Resources.LoadAll<Sprite>("цвета_картинки/цвета/предметы/" + tRes.targetColor);

            items[i].GetComponent<Image>().sprite = colorItems[Random.Range(0, colorItems.Length)];
            items[i].color = tRes.targetColor;
        } 

    }
    
}
