using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class pressOnColor_lvl1 : MonoBehaviour, IPointerClickHandler
{
    public string color;
    private AudioSource aS;



    void Start()
    {
        aS = GetComponent<AudioSource>();
    }


    public void OnPointerClick(PointerEventData pointerEventData)
    {
        string path = PlayerPrefs.GetString("voicePath");
        AudioClip clip = Resources.Load<AudioClip>(path + "Цвета/Уровень 1/" + color);
        aS.PlayOneShot(clip);
        Debug.Log(color + " clicked");
    }
}
