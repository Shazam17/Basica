using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Scalers : MonoBehaviour
{
    AudioSource audioSource;
    Animator animator;

    public PlayStartAnimation play;
    public int innerCounter = 0;
    public Text targerText;

    int changeTargetDir;
    bool changeDir = false;

    public GreetParticle particles;

    public void RepeatTask()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(task);
            play.PlayAnimation();
        }
    }

	void OnTriggerEnter2D(Collider2D col)
	{
        int weight = col.GetComponent<ScalableItem_lvl3>().weight;
        if (innerCounter == 0)
        {
            Debug.Log("changeDir");
            changeTargetDir = -1;
            changeDir = true;
        }
        innerCounter -= weight;
        
        if (weight != 1)
        {
            animator.SetInteger("dir", -weight);

        }
        else
        {
            animator.SetInteger("dir", -1);

        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        int weight = col.GetComponent<ScalableItem_lvl3>().weight;
        if (innerCounter == 0)
        {
            changeTargetDir = 1;
            Debug.Log("changeDir");
            changeDir = true;
        }

        innerCounter += weight;
        if (weight != 1)
        {
            animator.SetInteger("dir", weight);

        }
        else
        {
            animator.SetInteger("dir", 1);

        }

    }

    public void SetDirZero()
    {
        if (changeDir)
        {
            animator.SetInteger("dir", changeTargetDir);
            changeDir = false;
        }
        else
        {
            animator.SetInteger("dir", 0);
        }
    }
    AudioClip task;
    int randNumber;
    void Start()
    {
        randNumber = Random.Range(1, 11);
        innerCounter = randNumber;
        targerText.text = randNumber.ToString();
        Debug.Log($"set text eq: {randNumber}");
        animator = GetComponent<Animator>();
        animator.SetInteger("dir", randNumber);


        audioSource = GetComponent<AudioSource>();
        string path = Hooks.GetVoicePath();

        AudioClip clip = Resources.Load<AudioClip>(path + "Цифры/Уровень 3/конфетки/" + randNumber.ToString());
        AudioClip clip2 = Resources.Load<AudioClip>(path + "Цифры/Уровень 3/цифры/перетащи.. цифру " + randNumber.ToString());


        var way = Random.Range(0, 2);
        var found = GameObject.FindGameObjectsWithTag("Respawn");
        if (false)
        {
            var count = 1;
            foreach (var obj in found)
            {
                Sprite spr = Resources.Load<Sprite>("цифры_картинки/цифры в круге/" + count.ToString());
                obj.GetComponent<Image>().sprite = spr;
                obj.GetComponent<ScalableItem_lvl3>().weight = count;
                count++;

            }
            audioSource.PlayOneShot(clip2);
            task = clip2;
        }
        else
        {
            audioSource.PlayOneShot(clip);
            task = clip;
        }
    }
    bool was = false;
    bool pressed = false;
    public void scale()
    {
        SaveLoad save = new SaveLoad(levels.numbers);
        if (was || pressed)
        {
            return;
        }
        if (innerCounter == 0)
        {
            was = true;
            particles.TurnParticleOn();
            GameObject[] found = GameObject.FindGameObjectsWithTag("Respawn");
            foreach (var obj in found)
            {
                StartCoroutine(obj.GetComponent<ScalableItem_lvl3>().waitForAudio());
            }
  
            save.AddP(targerText.text);
            audioSource.Stop();
            StartCoroutine(Hooks.GetInstance().ToNewLevel("numbersLevel3", audioSource));
        }
        else
        {
            audioSource.Stop();
            save.AddM(targerText.text);
            save.AddM(Mathf.Abs(innerCounter).ToString());
            GameObject[] found = GameObject.FindGameObjectsWithTag("Respawn");
            foreach (var obj in found)
            {
                obj.GetComponent<ScalableItem_lvl3>().ToInit();
            }
            audioSource.Stop();
            Hooks.GetInstance().PlayDis(audioSource);
            StartCoroutine(Set());
        }
    }
    

    public IEnumerator Set()
    {
        if (!pressed)
        {
            pressed = true;
            yield return new WaitForSeconds(2.0f);
            animator.Play("eq");
            animator.SetInteger("dir", randNumber);
            pressed = false;
        }
    }
}
