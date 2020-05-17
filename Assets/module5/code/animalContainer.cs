using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class animalContainer : MonoBehaviour
{
    public string type;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioClip clip = Resources.Load<AudioClip>(Hooks.GetVoicePath() + "Животные/Уровень 2/перетащи.. родителю");
        audioSource.PlayOneShot(clip);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SaveLoad save = new SaveLoad(levels.animals);
        string otherType = other.GetComponent<animalChild>().type;
        if(string.Compare(type,otherType) == 0)
        {
            save.AddP(type);
            StartCoroutine(Hooks.GetInstance().ToNewLevel("animalsLevel2", audioSource));
        }
        else
        {
            save.AddM(type);
            Hooks.GetInstance().PlayDis(audioSource);
        }
    }
}
