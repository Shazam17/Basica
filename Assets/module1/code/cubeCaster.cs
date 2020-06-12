using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DigitalRubyShared;
using TouchPhase = DigitalRubyShared.TouchPhase;
using System;

public enum Direction
{
    LEFT,
    RIGHT,
    UP,
    DOWN,
    STATIC
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
        if (Input.GetMouseButtonDown(0))
        {
            if (!pressed)
            {
                canPress = false;
                pressed = true;
                startGestureCord = newPos;
            }
        }
        if (pressed)
        {

            float len = (curPos - newPos).magnitude;
            float lenFromStart = (newPos - startGestureCord).magnitude;
            if(len < 0.00000001f)
            {
                dir = Direction.STATIC;
                deltaY = 0.0f;
            }
            else
            {
                if (lenFromStart < lastLen)
                {
                    startGestureCord = newPos;
                    len = 0;
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
        }
        if (Input.GetMouseButtonUp(0))
        {
            pressed = false;
            return true;
        }

        return false;
    }

    public bool getPressed()
    {
        return pressed;
    }
  
    public bool getCanPress()
    {
        return canPress;
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

    //private OneTouchRotateGestureRecognizer gest;
    public bool inCenter = false;
    string inCenterCube;
    public GameObject centerObject;


    AudioClip clip;
    public levelType type;
    private AudioSource audioSource;
    public GameObject[] cubes;
    public float sensitivity = 0.1f;
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
        for(int i = 0; i < 14; i++)
        {
            float left = -11.5f + offset;
            for (int j = 0; j < 3; j++)
            {
                if(j + 3 * i < cubes.Length)
                {
                    cubes[j].transform.position = new Vector3(left, top, 0);
                    cubes[j + 3 * i].transform.position = new Vector3(left, top - offset * i, 0);
                    cubes[j + 3 * i].transform.Rotate(new Vector3(-10, 10, 0));
                }
             

                left += offset + marginLeft;
            }
        }
          foreach(var cube in cubes)
        {
            cube.GetComponent<cubeScript>().audioSource = audioSource;
        }
            top -= sizeOfPrefab + marginTop;
        


     
    }
    
    void Start()
    {
        //gest = new OneTouchRotateGestureRecognizer();
        //gest.Updated += callback;
        //FingersScript.Instance.ResetState(true);
        //FingersScript.Instance.AddGesture(gest);

        gameObject.AddComponent<Gesture>();
        gesture = GetComponent<Gesture>();
    }


  

    
  
    Gesture gesture;

    enum CubeParentState
    {
        STATIC,
        MOVING,
        BOUNCING,
        STOP,
        CENTER
    }

    CubeParentState state;

    void cubeControlStateMachine()
    {

    }
    void controlCubeParent()
    {
        Vector3 pos = cubeParent.transform.position;
        bool ret = gesture.inputGesture(Input.mousePosition);
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
            cubeParent.transform.Translate(new Vector3(0, gesture.deltaY));
        }
    
        if (ret)
        {
            StartCoroutine(SmoothStop());
        }
    }

    void Update()
    {
        Debug.Log(gesture.dir);
        controlCubeParent();
        processCubeCast();
    }

    public void processCubeCast()
    {
        
        if (Input.GetMouseButtonDown(0) && gesture.dir == Direction.STATIC)
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                hit.collider.GetComponent<playAudioCube>().Play();
            }
        }


    }

    public IEnumerator SmoothStop(int steps = 70)
    {
        float initial = gesture.deltaY;
        for (float i = 0; i < steps; i++)
        {
            if (gesture.pressed)
            {
                break;
            }
            yield return new WaitForSeconds(0.005f);
            float t = Mathf.Lerp(initial,0 , i / steps);
            gesture.deltaY = t;
        }
        gesture.dir = Direction.STATIC;
        gesture.deltaY = 0f;
        
    }

    //void callback(GestureRecognizer gesture, ICollection<GestureTouch> touches)
    //{
    //    if (isMoving)
    //    {
    //        Debug.Log("isMoving");
    //        return;
    //    }
    //    if(audioSource != null)
    //    {
    //        if(audioSource.isPlaying)
    //        {
    //            if (isMoving)
    //            {
    //                return;
    //            }
    //        }
    //    }
    //    else
    //    {
    //        if (isMoving)
    //        {
    //            return;
    //        }
    //    }


    //    if (inCenter && !isMoving)
    //    {
    //        foreach(var touch in touches)
    //        {
    //            float magnitude = (new Vector2(touch.DeltaX, touch.DeltaY)).magnitude;
    //            if(magnitude < 0.01f && touch.TouchPhase != TouchPhase.Moved)
    //            {   
    //            }
    //        }
    //        centerObject.transform.Rotate(new Vector3(gesture.DeltaY, -gesture.DeltaX, 0), Space.World);
    //    }
    //    else
    //    {
    //        if (cubeParent != null && scroll && !isMoving)
    //        {
    //            Vector3 pos = cubeParent.transform.position;
    //            if (pos.y > minY && gesture.DeltaY > 0)
    //            {
    //                return;
    //            }
    //            if (pos.y < maxY && gesture.DeltaY < 0)
    //            {
    //                return;
    //            }
    //            cubeParent.transform.Translate(new Vector3(0, gesture.DeltaY * 0.5f * Time.deltaTime));
    //        }

    //    }


    //}

    //public bool isMoving = false;
    //bool fingerOnScreen = false;
    //public bool count = false;
    //Vector2 lastPos;

    //void Update()
    //{
    //    if (isMoving || audioSource.isPlaying)
    //    {
    //        return;
    //    }
    //    if (Input.GetMouseButtonDown(0) || (Input.touches.Length == 1 && Input.touches[0].phase == UnityEngine.TouchPhase.Began))
    //    {    
    //        fingerOnScreen = true;     
    //        if (Input.touches.Length == 0)
    //        {
    //            lastPos = Input.mousePosition;
    //        }
    //        else
    //        {
    //            lastPos = Input.touches[0].position;
    //        }
    //    }
    //    if (inCenter)
    //    {
    //        if (Input.GetMouseButtonUp(0) || (Input.touches.Length == 1 && Input.touches[0].phase == UnityEngine.TouchPhase.Ended))
    //        {
    //            float magn;
    //            if (Input.touches.Length == 0)
    //            {
    //                magn = (lastPos - new Vector2(Input.mousePosition.x, Input.mousePosition.y)).magnitude;
    //            }
    //            else
    //            {
    //                magn = (lastPos - Input.touches[0].position).magnitude;
    //            }
    //            bool flag = true;
    //            Ray ray;
    //            if(Input.touches.Length == 0)
    //            {
    //                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //            }
    //            else
    //            {
    //                ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
    //            }
    //            RaycastHit hit;
    //            if (Physics.Raycast(ray, out hit))
    //            {

    //                if (hit.collider.transform.parent.name == inCenterCube)
    //                {
    //                    flag = false;
    //                }
    //            }
    //            int playingGlobal = PlayerPrefs.GetInt("playing");
    //            if (magn < 4 && inCenter && flag && !isMoving && playingGlobal == 0)
    //            {
    //                centerObject.GetComponent<cubeScript>().ToInitial();
    //                centerObject.transform.localScale = new Vector3(4.5f,4.5f,4.5f);
    //                StartCoroutine(wait());



    //            }
    //            fingerOnScreen = false;
    //            Debug.Log("finger off screen");
    //        }

    //        if (Input.GetMouseButtonDown(0) ||(Input.touches.Length == 1 && Input.touches[0].phase == UnityEngine.TouchPhase.Began))
    //        { // if left button pressed...
    //            Ray ray;
    //            if (Input.touches.Length == 0)
    //            {
    //                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //            }
    //            else
    //            {
    //                ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
    //            }
    //            RaycastHit hit;
    //            if (Physics.Raycast(ray, out hit))
    //            {
    //                if (hit.collider.transform.parent.name == inCenterCube)
    //                {
    //                    Debug.Log(hit.collider.name);
    //                    Debug.Log(hit.collider.transform.parent.name);
    //                    hit.collider.GetComponent<playAudioCube>().Play();
    //                    count = false;
    //                }
    //            }
    //        }
    //    }
    //    else
    //    {
    //        var go = PlayerPrefs.GetInt("playing");
    //        if (Input.GetMouseButtonDown(0) || ( Input.touches.Length == 1 &&  Input.touches[0].phase == UnityEngine.TouchPhase.Began) && !isMoving && !inCenter)
    //        { // if left button pressed...
    //            Ray ray;
    //            if(Input.touches.Length == 0)
    //            {
    //                ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
    //            }
    //            else
    //            {
    //                ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
    //            }
    //            RaycastHit hit;
    //            if (Physics.Raycast(ray, out hit))
    //            {
    //                if (!count && !audioSource.isPlaying && !isMoving  && go == 0)
    //                {
    //                    count = true;
    //                    hit.collider.GetComponent<playAudioCube>().Play();
    //                    inCenterCube = hit.collider.transform.parent.name;
    //                    StartCoroutine(waitPress(1f));
    //                    centerObject = hit.collider.transform.parent.gameObject;
    //                    return;
    //                }
    //                if (count && inCenterCube.Equals(hit.collider.transform.parent.name) && !centerObject.GetComponent<AudioSource>().isPlaying && go == 0)
    //                {

    //                    inCenterCube = hit.collider.transform.parent.name;
    //                    hit.collider.GetComponentInParent<cubeScript>().ToCenter();
    //                    centerObject = hit.collider.transform.parent.gameObject;
    //                    Debug.Log(hit.collider.transform.parent.name);
    //                    hit.collider.transform.parent.transform.localScale = new Vector3(4.5f, 4.5f, 4.5f);
    //                    StartCoroutine(wait(3f));
    //                    count = false;

    //                }
    //                else 
    //                {
    //                    if(!centerObject.GetComponent<AudioSource>().isPlaying && !isMoving && go == 0)
    //                    {
    //                        count = true;
    //                        hit.collider.GetComponent<playAudioCube>().Play();
    //                        StartCoroutine(waitPress(1f));
    //                        inCenterCube = hit.collider.transform.parent.name;
    //                        return;
    //                    }                 
    //                } 
    //            }
    //        }
    //    }

    //}
    //IEnumerator waitPress(float seconds = 2.0f)
    //{
    //    PlayerPrefs.SetInt("playing", 1);
    //    isMoving = true;
    //    yield return new WaitForSeconds(seconds);
    //    isMoving = false;
    //    PlayerPrefs.SetInt("playing", 0);

    //}


    //IEnumerator wait(float seconds = 2.0f)
    //{
    //    isMoving = true;
    //    yield return new WaitForSeconds(seconds);
    //    isMoving = false;
    //    inCenter = !inCenter;



    //}
}
