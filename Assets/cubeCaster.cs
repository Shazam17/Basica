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
        if (inCenter)
        {
            foreach(var touch in touches)
            {
                float magnitude = (new Vector2(touch.DeltaX, touch.DeltaX)).magnitude;
                if(magnitude < 0.01f && touch.TouchPhase != TouchPhase.Moved)
                {
                    //centerObject.GetComponent<cubeScript>().ToInitial();
                    //inCenter = false;
                }
            }

            centerObject.transform.Rotate(new Vector3(0, 1, 0), -gesture.DeltaX *0.5f );
            centerObject.transform.Rotate(new Vector3(1, 0, 0), gesture.DeltaY * 0.5f);
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


    void Update()
    {
        if (inCenter)
        {
            if (Input.GetMouseButtonDown(0) || ( Input.touches.Length == 1 &&  Input.touches[0].phase == UnityEngine.TouchPhase.Ended))
            { // if left button pressed...
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.transform.parent.name == inCenterCube)
                    {
                        Debug.Log(hit.collider.transform.parent.name);
                        hit.collider.GetComponent<playAudioCube>().Play();
                    }
                }
                if(Input.touches.Length == 1 && Input.touches[0].deltaPosition.magnitude < 0.1f )
                {
                    centerObject.GetComponent<cubeScript>().ToInitial();
                    inCenter = false;
                }

                

            }

        }
        else
        {
            if (Input.GetMouseButtonDown(0) || ( Input.touches.Length == 1 &&  Input.touches[0].phase == UnityEngine.TouchPhase.Ended))
            { // if left button pressed...
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    inCenter = true;
                    inCenterCube = hit.collider.transform.parent.name;
                    hit.collider.GetComponentInParent<cubeScript>().ToCenter();
                    centerObject = hit.collider.transform.parent.gameObject;
                }
            }
        }

    }

}
