﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Direction
{
    LEFT,
    RIGHT,
    UP,
    DOWN,
    STATIC
}

public static class InputController
{
    public static bool GetInputDown()
    {
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                return true;
            }
            return false;
        }
        return Input.GetMouseButtonDown(0);
    }

    public static bool GetInputUp()
    {
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                return true;
            }
            return false;
        }
        return Input.GetMouseButtonUp(0);
    }
}


public class Gesture : MonoBehaviour
{


    Vector2 startGestureCord;
    Vector2 curPos;

    Vector2 up;
    Vector2 left;
    public bool pressed = false;
    public Direction dir;
    
    public float deltaY = 0.0f;
    public Gesture()
    {
        up = new Vector2(0, 1);
        left = new Vector2(-1, 0);
    }

    public float lastLen;
    public bool canPress = true;

    public bool inputGesture(Vector2 newPos)
    {
        if (InputController.GetInputDown())
        {
            if (!pressed)
            {
                lastLen = 0.0f;
                canPress = false;
                pressed = true;
                startGestureCord = newPos;
            }
            return false;
        }

        if (pressed)
        {

            float len = (curPos - newPos).magnitude;
            float lenFromStart = (newPos - startGestureCord).magnitude;

            if(lenFromStart > 0.00000001f)  
            {
                if (lenFromStart < lastLen)
                {
                    startGestureCord = newPos;
                    len = 0;
                    lastLen = 0.0f;
                }
                lastLen = lenFromStart;
                curPos = newPos;
                Vector2 direction = newPos - startGestureCord;
                direction = direction.normalized;
                float dot = Vector2.Dot(direction, up);


                if (dot > 0.99)
                {
                    dir = Direction.UP;
                }
                if (dot < -0.99)
                {
                    dir = Direction.DOWN;
                }
                deltaY = dot * Time.deltaTime * len;
            }
            else
            {
                dir = Direction.STATIC;
                deltaY = 0;
            }
        
               
        }
        

      
        
        if (InputController.GetInputUp())
        {
            pressed = false;
            return true;
        }
        return false;
    }
}

public class cubeCaster : MonoBehaviour
{
    public bool scroll = true;
    public enum levelType
    {
        letters,
        numbers,
        colors,
        figures
    }

    AudioClip clip;
    public levelType type;
    private AudioSource audioSource;
    public GameObject[] cubes;
    public float sensitivity = 1.0f;
    public float offset = 3.0f;
    public float sizeOfPrefab = 4.0f;
    public float marginLeft = 1.0f;
    public float marginTop = 1.0f;
    public float minY = 23;
    public float maxY = -2;
    public void PlayProlog()
    {
        int playingGlobal = PlayerPrefs.GetInt("playing");
        if (!audioSource.isPlaying && playingGlobal == 0)
        {

            audioSource.PlayOneShot(clip);
            //StartCoroutine(waitPress(2.0f));

        }
    }

    public GameObject cubeParent;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        string path = Hooks.GetVoicePath();
        if(type == levelType.letters)
        {
            AudioClip clip = Resources.Load<AudioClip>(path + "Буквы/Уровень 1/поизучаем буквы");
            audioSource.PlayOneShot(clip);
            this.clip = clip;
            
        }else if(type == levelType.numbers)
        {
            AudioClip clip = Resources.Load<AudioClip>(path + "Цифры/Уровень 1 пролог/поизучаем цифры");
            audioSource.PlayOneShot(clip);
            this.clip = clip;
        }
        else if(type == levelType.colors)
        {
            AudioClip clip = Resources.Load<AudioClip>(path + "Цвета/Уровень 1 пролог/поизучаем цвета");
            audioSource.PlayOneShot(clip);
            this.clip = clip;
        }
        else if (type == levelType.figures)
        {
            AudioClip clip = Resources.Load<AudioClip>(path + "Фигуры/Уровень 1 пролог/поизучаем фигуры");
            audioSource.PlayOneShot(clip);
            this.clip = clip;
        }
        //StartCoroutine(waitPress(2.0f));

        float top = 3.0f - marginTop;
        for (int i = 0; i < 14; i++)
        {
            float left = -11.5f + offset;
            for (int j = 0; j < 3; j++)
            {
                if (j + 3 * i < cubes.Length)
                {
                    cubes[j].transform.position = new Vector3(left, top, 0);
                    cubes[j + 3 * i].transform.position = new Vector3(left, top - offset * i, 0);
                    cubes[j + 3 * i].transform.Rotate(new Vector3(-10, 10, 0));
                }


                left += offset + marginLeft;
            }
        }
        foreach (var cube in cubes)
        {
            cube.GetComponent<cubeScript>().audioSource = audioSource;
        }

        top -= sizeOfPrefab + marginTop;
    }
    
    void Start()
    {
        gameObject.AddComponent<Gesture>();
        gesture = GetComponent<Gesture>();
    }

    Gesture gesture;

 
    void controlCubeParent()
    {
        Vector3 pos = cubeParent.transform.position;
        Vector2 input;
        if(Input.touches.Length == 0)
        {
            input = Input.mousePosition;
        }
        else
        {
            input = Input.touches[0].position;
        }
        bool ret = gesture.inputGesture(input);
        if (pos.y > minY && gesture.deltaY > 0)
        { 
            return;
        }
        if (pos.y < maxY && gesture.deltaY < 0)
        {
            return;
        }
        if (gesture.dir == Direction.UP || gesture.dir == Direction.DOWN )
        {
            cubeParent.transform.Translate(new Vector3(0,sensitivity * gesture.deltaY,0));
        }
    
        if (ret)
        {
            StartCoroutine(SmoothStop());
        }
    }

    void Update()
    {
        controlCubeParent();
        processCubeCast();
    }

    class CubeCastController
    {

        bool inCenter = false;
        int clicks = 0;


       

    }

    public void processCubeCast()
    {
        
        if (InputController.GetInputUp() && !gesture.pressed && gesture.dir == Direction.STATIC && gesture.deltaY == 0.0f)
        {
            Ray ray;
            if (Input.touches.Length == 0)
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            }
            
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                hit.collider.GetComponent<playAudioCube>().Play();
            }
        }
    }

    public IEnumerator SmoothStop(int steps = 70)
    {
        Debug.Log("smooth stopping");
        float initial = gesture.deltaY;
        bool stopped = false;
        Vector3 pos = cubeParent.transform.position;
        for (float i = 0; i < steps; i++)
        {
            if (gesture.pressed)
            {
                stopped = true;
                break;
            }
            if (pos.y > minY && gesture.deltaY > 0)
            {
                break;
            }
            if (pos.y < maxY && gesture.deltaY < 0)
            {
                break;
            }
            yield return new WaitForSeconds(0.005f);
            float t = Mathf.Lerp(initial,0 , i / steps);
            gesture.deltaY = t;
        }
        if (!stopped)
        {
            gesture.dir = Direction.STATIC;
            gesture.pressed = false;
            gesture.deltaY = 0f;
        }
      
        
    }

}
