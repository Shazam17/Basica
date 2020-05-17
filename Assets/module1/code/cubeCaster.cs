using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;
using TouchPhase = DigitalRubyShared.TouchPhase;

public class cubeCaster : MonoBehaviour
{
    private OneTouchRotateGestureRecognizer gest;
    public bool inCenter = false;
    string inCenterCube;
    public GameObject centerObject;


    public GameObject[] cubes;
    public float sensitivity = 0.1f;
    public float offset = 3.0f;
    public float sizeOfPrefab = 4.0f;
    public float marginLeft = 1.0f;
    public float marginTop = 1.0f;



    public GameObject cubeParent;
    void Start()
    {    
            float top = 3.0f - marginTop;       
        for(int i = 0; i < 7; i++)
        {
            float left = -9.0f + offset;
            for (int j = 0; j < 5; j++)
            {
                if(j + 5 * i < cubes.Length)
                {
                    cubes[j].transform.position = new Vector3(left, top, 0);
                    cubes[j + 5 * i].transform.position = new Vector3(left, top - offset * i, 0);
                }
             

                left += sizeOfPrefab + marginLeft;
            }
        }
          
            top -= sizeOfPrefab + marginTop;
        


        gest = new OneTouchRotateGestureRecognizer();
        gest.Updated += callback;
        FingersScript.Instance.AddGesture(gest);
    }


    void callback(GestureRecognizer gesture, ICollection<GestureTouch> touches)
    {

        if (isMoving)
        {
            return;
        }

        if (inCenter && !isMoving)
        {
            foreach(var touch in touches)
            {
                float magnitude = (new Vector2(touch.DeltaX, touch.DeltaY)).magnitude;
                if(magnitude < 0.01f && touch.TouchPhase != TouchPhase.Moved)
                {
                    //centerObject.GetComponent<cubeScript>().ToInitial();
                    //inCenter = false;
                }
            }
            centerObject.transform.Rotate(new Vector3(gesture.DeltaY, -gesture.DeltaX, 0), Space.World);
        }
        else
        {
            Vector3 pos = cubeParent.transform.position;
            if (pos.y > -17 && gesture.DeltaY > 0)
            {
                return;
            }
            if (pos.y < -35 && gesture.DeltaY < 0)
            {
                return;
            }
            cubeParent.transform.Translate(new Vector3(0, gesture.DeltaY * 0.5f * Time.deltaTime));
        }
     
    
    }

    bool isMoving = false;
    bool fingerOnScreen = false;
    bool count = false;
    Vector2 lastPos;

    void Update()
    {
        if (isMoving)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0) || (Input.touches.Length == 1 && Input.touches[0].phase == UnityEngine.TouchPhase.Began))
        {
           
            fingerOnScreen = true;
           

            if (Input.touches.Length == 0)
            {
                lastPos = Input.mousePosition;
            }
            else
            {
                lastPos = Input.touches[0].position;
            }
            
            Debug.Log("finger on screen");
        }
       

        if (inCenter)
        {

            if (Input.GetMouseButtonUp(0) || (Input.touches.Length == 1 && Input.touches[0].phase == UnityEngine.TouchPhase.Ended))
            {


                float magn;
                if (Input.touches.Length == 0)
                {
                    magn = (lastPos - new Vector2(Input.mousePosition.x, Input.mousePosition.y)).magnitude;
                }
                else
                {
                    magn = (lastPos - Input.touches[0].position).magnitude;
                }
                Debug.Log(magn);


                bool flag = true;
                Ray ray;
                if(Input.touches.Length == 0)
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

                    if (hit.collider.transform.parent.name == inCenterCube)
                    {
                        flag = false;
                    }
                }

                if (magn < 4 && inCenter && flag)
                {
                    centerObject.GetComponent<cubeScript>().ToInitial();
                    StartCoroutine(wait());

                }
                fingerOnScreen = false;
                Debug.Log("finger off screen");
            }

            if (Input.GetMouseButtonDown(0) || ( Input.touches.Length == 1 &&  Input.touches[0].phase == UnityEngine.TouchPhase.Stationary))
            { // if left button pressed...
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
                    if (hit.collider.transform.parent.name == inCenterCube)
                    {
                        Debug.Log(hit.collider.name);
                        Debug.Log(hit.collider.transform.parent.name);
                        hit.collider.GetComponent<playAudioCube>().Play();
                    }
                }
               

                

            }

        }
        else
        {
            if (Input.GetMouseButtonDown(0) || ( Input.touches.Length == 1 &&  Input.touches[0].phase == UnityEngine.TouchPhase.Stationary))
            { // if left button pressed...
                Ray ray;
                if (isMoving || inCenter)
                {
                    return;
                }
                if(Input.touches.Length == 0)
                {
                    ray  = Camera.main.ScreenPointToRay(Input.mousePosition);
                }
                else
                {
                    ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
                }
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (!count)
                    {
                        count = true;
                        hit.collider.GetComponent<playAudioCube>().Play();
                        return;
                    }
                    if (count)
                    {
                        inCenterCube = hit.collider.transform.parent.name;
                        hit.collider.GetComponentInParent<cubeScript>().ToCenter();
                        centerObject = hit.collider.transform.parent.gameObject;
                        StartCoroutine(wait());
                        count = false;
                       
                    }

                 
                }
            }
        }

    }
    IEnumerator wait()
    {
        isMoving = true;
        yield return new WaitForSeconds(0.7f);
        isMoving = false;
        inCenter = !inCenter;

    }
}
