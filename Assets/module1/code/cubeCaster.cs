using System.Collections;
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
    Vector2 right;
    public bool pressed = false;
    public Direction dir;

   
    public float deltaY = 0.0f;
    public float deltaX = 0.0f;

    public Gesture()
    {
        up = new Vector2(0, 1);
        right = new Vector2(1, 0);
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

                float dotX = Vector2.Dot(direction, right);

                if (dot > 0.99)
                {
                    dir = Direction.UP;
                }
                if (dot < -0.99)
                {
                    dir = Direction.DOWN;
                }

                deltaX = dotX * Time.deltaTime * 75;


                deltaY = dot * Time.deltaTime * 75;
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
    cubeScript centerObjectScript;
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
            AudioClip clipLoad = Resources.Load<AudioClip>(path + "Буквы/Уровень 1/поизучаем буквы");
            audioSource.PlayOneShot(clipLoad);
            this.clip = clipLoad;
            
        }else if(type == levelType.numbers)
        {
            AudioClip clipLoad = Resources.Load<AudioClip>(path + "Цифры/Уровень 1 пролог/поизучаем цифры");
            audioSource.PlayOneShot(clipLoad);
            this.clip = clipLoad;
        }
        else if(type == levelType.colors)
        {
            AudioClip clipLoad = Resources.Load<AudioClip>(path + "Цвета/Уровень 1 пролог/поизучаем цвета");
            audioSource.PlayOneShot(clipLoad);
            this.clip = clipLoad;
        }
        else if (type == levelType.figures)
        {
            AudioClip clipLoad = Resources.Load<AudioClip>(path + "Фигуры/Уровень 1 пролог/поизучаем фигуры");
            audioSource.PlayOneShot(clipLoad);
            this.clip = clipLoad;
        }
        //StartCoroutine(waitPress(2.0f));

        float top = 3.0f - marginTop;
        for (int i = 0; i < 14; i++)
        {
            float left = -11.5f + offset;
            for (int j = 0; j < 4; j++)
            {
                if (j + 4 * i < cubes.Length)
                {
                    cubes[j].transform.position = new Vector3(left, top, 0);
                    cubes[j].transform.localScale = new Vector3(3, 3, 3);
                    cubes[j + 4 * i].transform.position = new Vector3(left, top - marginTop * i, 0);
                    cubes[j + 4 * i].transform.Rotate(new Vector3(-10, 10, 0));
                    cubes[j + 4 * i].transform.localScale = new Vector3(3, 3, 3);
                }


                left += marginLeft;
            }
        }
        foreach (var cube in cubes)
        {
            cube.GetComponent<cubeScript>().Init(audioSource);
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

        if (inCenter)
        {
            if (ret)
            {
                StartCoroutine(SmoothStopCenter());
            }
            return;
        }

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

        if ((centerObjectScript != null && !centerObjectScript.isMoving) || centerObjectScript == null)
        {
            processCubeCast();
        }
        if (inCenter)
        {
            rotateCenterObject();
        }
      
    }

    public void rotateCenterObject()
    {
        if(centerObjectScript != null && !centerObjectScript.isMoving)
        {
            centerObject.transform.Rotate(new Vector3(gesture.deltaY * 1.5f, -gesture.deltaX * 1.5f, 0f), Space.World);
        }
    }

    public bool inCenter = false;
    bool count = false;
    public GameObject centerObject;
    string lastTouchName;
    public GameObject blurBack;
    public void processRay(Collider collider)
    {
        if (!inCenter)
        {
            if(collider.name != "0")
            {
                return;
            }
            if (!count)
            {
                collider.GetComponent<playAudioCube>().Play();
                lastTouchName = collider.transform.parent.name;
                count = true;
            }
            else
            {
                if(lastTouchName == collider.transform.parent.name)
                {
                    blurBack.GetComponent<Animator>().Play("BlurApear");
                    collider.transform.parent.GetComponent<cubeScript>().ToCenter();
                    centerObject = collider.transform.parent.gameObject;
                    centerObjectScript = collider.transform.parent.GetComponent<cubeScript>();
                    lastTouchName = "";
                    inCenter = true;
                    count = false;
                    blurBack.SetActive(true);
                    collider.transform.parent.GetComponent<Animator>().Play("cubeZoom");
                }
                else
                {
                  
                    collider.GetComponent<playAudioCube>().Play();
                    lastTouchName = collider.transform.parent.name;
                    count = true;
                }
            }
        }
        else
        {
            Debug.Log(collider.transform.name);
            if (collider.transform.parent == null)
            {
                centerObject.GetComponent<cubeScript>().ToInitial();
                centerObject.GetComponent<Animator>().Play("cubeZoomOut");
                blurBack.GetComponent<Animator>().Play("BlurDisApear");
                StartCoroutine(waitForCube());
            }
            if (centerObject.name == collider.transform.parent.name)
            {
                collider.GetComponent<playAudioCube>().Play();
            }
            else
            {
                centerObject.GetComponent<cubeScript>().ToInitial();
                centerObject.GetComponent<Animator>().Play("cubeZoomOut");
                blurBack.GetComponent<Animator>().Play("BlurDisApear");
                StartCoroutine(waitForCube());
            }
        }
        
    }

    public IEnumerator waitForCube()
    {
        while (centerObjectScript.isMoving)
        {
            yield return new WaitForSeconds(0.01f);
            
        }
        inCenter = false;
        centerObject = null;
        centerObjectScript = null;
    }

    public void processCubeCast()
    {
        if (audioSource.isPlaying)
        {
            return;
        }
        if (InputController.GetInputUp()
            && !gesture.pressed
            && gesture.dir == Direction.STATIC
            && Mathf.Abs(gesture.deltaY) < 0.000001f)
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
                processRay(hit.collider);
            }
            else
            { 
                centerObject.GetComponent<cubeScript>().ToInitial();
                centerObject.GetComponent<Animator>().Play("cubeZoomOut");
                blurBack.GetComponent<Animator>().Play("BlurDisApear");
                StartCoroutine(waitForCube());
            }
        }
    }
    public IEnumerator SmoothStopCenter(int steps = 35)
    {
        Debug.Log("smooth stopping");
        float initialX = gesture.deltaX;
        float initialY = gesture.deltaY ;
        bool stopped = false;
        for (float i = 0; i < steps; i++)
        {
            if (gesture.pressed)
            {
                stopped = true;
                break;
            }
            yield return new WaitForSeconds(0.005f);
            float tX = Mathf.Lerp(initialX, 0, i / steps);
            float tY = Mathf.Lerp(initialY, 0, i / steps);
            gesture.deltaY = tY;
            gesture.deltaX = tX;
        }
        if (!stopped)
        {
            gesture.dir = Direction.STATIC;
            gesture.pressed = false;
            gesture.deltaY = 0f;
            gesture.deltaX = 0f;
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
