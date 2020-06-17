using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayColor : MonoBehaviour
{
    List<Sprite> colors;
    List<AudioClip> clips;

    Image img;
    Animator animator;

    public GameObject spawningObject;
    public Transform list;
    public AnimationClip fadeIn;
    public AnimationClip fadeOut;

    public AudioSource audioSource;

    void Start()
    {
        PlayerPrefs.SetInt("canTouch", 0);
        var path = Hooks.GetVoicePath();
        Sprite[] colorArray = Resources.LoadAll<Sprite>("цвета_картинки/Уровень 1/");
        AudioClip[] colorClips = Resources.LoadAll<AudioClip>(path + "Цвета/Уровень 1/");

        colors = new List<Sprite>(colorArray);
        clips = new List<AudioClip>(colorClips);


        img = GetComponent<Image>();
        animator = GetComponent<Animator>();

       


        lastImage = colors[0];
        colors.RemoveAt(0);

        last = clips.Find(x => x.name == lastImage.name);
        clips.Remove(last);

        img.sprite = lastImage;
        animator.Play(fadeIn.name);
    }

    AudioClip last;
    Sprite lastImage;
    public bool lck = false;

    public void PopColor()
    {
        if (audioSource.isPlaying || lck)
        {
            return;
        }

        animator.Play(fadeOut.name);

        var go = Instantiate(spawningObject);
        go.transform.SetParent(list);
        go.GetComponent<Image>().sprite = lastImage;

        var audioColor = go.GetComponent<AudioColor>();
        audioColor.audioSource = audioSource;
        audioColor.clip = last;


    }


    public void SetLock()
    {
        lck = true;
    }

    public void Unlock()
    {
        
        if (colors.Count == 0)
        {
            PlayerPrefs.SetInt("canTouch", 1);
            transform.parent.gameObject.SetActive(false);
            return;
        }
        lastImage = colors[0];

        colors.RemoveAt(0);

        last = clips.Find(x => x.name == lastImage.name);
        clips.Remove(last);

        img.sprite = lastImage;
        animator.Play(fadeIn.name);
    }


    public void PlayAudio()
    {
        lck = false;
        audioSource.PlayOneShot(last);
    }

  
}
