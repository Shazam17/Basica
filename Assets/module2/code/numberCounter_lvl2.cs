using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class numberCounter_lvl2 : MonoBehaviour
{

    public int counter = 0;
    public int targerCount = 3;

    public RectTransform startSpawnPoint;
    public GameObject spawningObject;
    public Transform parent;
    public AudioSource audioSource;


    void Start()
    {
        int type = Random.Range(1, 10);
        string path = Hooks.GetVoicePath();

        AudioClip[] targetClips = Resources.LoadAll<AudioClip>(path + "Цифры/Уровень 2/" + type.ToString());




        audioSource = GetComponent<AudioSource>();
        int randNumber = Random.Range(1, 10);

        Sprite textureTemp = Resources.Load<Sprite>("lvl2_2_basket/" + randNumber.ToString());
        GetComponent<Image>().sprite = textureTemp;

        foreach(var clip in targetClips)
        {
            if (clip.name.Contains(" " + randNumber.ToString() + " "))
            {
                audioSource.PlayOneShot(clip);
            }
        }
           
        

        

        targerCount = randNumber;

        int n = randNumber;
        if(randNumber < 10)
        {
            n = randNumber + 1;
        }
        if (randNumber < 5)
        {
            n = randNumber + 2;
        }

        Vector3 move = new Vector3(100, 0,0);
        for (int i = 0; i < n && i < 5; i++)
        {
            var go = Instantiate(spawningObject, startSpawnPoint);
            go.transform.SetParent(parent);
            go.GetComponent<dragNumber>().LoadWithImage(type);
            startSpawnPoint.localPosition += move ;
        }

        startSpawnPoint.localPosition += new Vector3(0, -80, 0);
        startSpawnPoint.localPosition += new Vector3(-500,0 ,0);
        for (int i = 5; i < n; i++)
        {
            var go = Instantiate(spawningObject, startSpawnPoint);
            go.transform.SetParent(parent);
            go.GetComponent<dragNumber>().LoadWithImage(type);
            startSpawnPoint.localPosition += move;
        }
    }

  
    public void EndLevel()
    {
        if (counter == targerCount)
        {
            StartCoroutine(Hooks.GetInstance().ToNewLevel("numbersLevel2", audioSource));
        }
        else
        {
            Hooks.GetInstance().PlayDis(audioSource);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        counter += other.GetComponent<dragNumber>().weight;
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        counter -= other.GetComponent<dragNumber>().weight;
        Debug.Log("letter goes");
    }


}
