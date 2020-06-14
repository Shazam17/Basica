﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeScript : MonoBehaviour
{

    public GameObject[] faces;
    public Texture2D[] sprites;
    public AudioClip[] clipsW;
    public AudioClip[] clipsM;

    public AudioSource audioSource;

    public GameObject center;
    Vector3 initialPlace;

    public bool disabled = false;
    // Start is called before the first frame update
    void Start()
    {
       
        
        faces[0].transform.localPosition = new Vector3(0, 0.157f, -0.5f);
        faces[1].transform.localPosition = new Vector3(0, -0.343f, 0);
        faces[2].transform.localPosition = new Vector3(-0.5f, 0.157f, 0);
        faces[3].transform.localPosition = new Vector3(0.5f, 0.157f, 0);
        faces[4].transform.localPosition = new Vector3(0, 0.65f, 0);
        faces[5].transform.localPosition = new Vector3(0, 0.157f, 0.5f);

        for (int i = 0; i < faces.Length; i++)
        {
            faces[i].GetComponent<MeshRenderer>().material.mainTexture = sprites[i];
           
            if (PlayerPrefs.GetString("voicePath") == "женский/")
            {
                faces[i].GetComponent<playAudioCube>().GetComponent<AudioSource>().clip = clipsW[i];
            }
            else
            {
                faces[i].GetComponent<playAudioCube>().GetComponent<AudioSource>().clip = clipsM[i];
            }
        }
    }


    public void ToCenter()
    {
        initialPlace = transform.position;
        StartCoroutine(moveTo(center.transform.position));  
    }

    public void ToInitial()
    {

        StartCoroutine(moveTo(initialPlace));
    }

    public bool isMoving = false;


    IEnumerator moveTo(Vector3 to)
    {
        isMoving = true;
        Vector3 diff = to - transform.position;
        while (diff.magnitude > 0.1f)
        {
            yield return new WaitForSeconds(0.01f);
            diff = to - transform.position;

            Vector3 dir = diff.normalized;

            transform.position += dir * 0.1f;
            
        }
        transform.position = to;
        isMoving = false;
        if(to == initialPlace)
        {
            transform.rotation = new Quaternion(0,0,0,0);
        }
        transform.rotation = Quaternion.Euler(new Vector3(-10, 10, 0));
    }

  
}
