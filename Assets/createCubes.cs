using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;


public class createCubes : MonoBehaviour
{
    private OneTouchRotateGestureRecognizer gest;


    public moveToCenter3D inCenterObject;
    public Transform cubeParent;
    public GameObject prefab;
    public Vector2 leftLowerCorner = new Vector2(-9, -5);
    public Vector2 rightUpperCorner = new Vector2(9, 5);
    public float width = 18;
    public float height = 10;
    public bool isOnScreen = false;


    public Vector3 startRotVector = new Vector3(0,0,0);
    Quaternion startRot;

    public float sensitivity = 0.1f;
    public float offset = 3.0f;
    public float sizeOfPrefab = 2.0f;
    public float marginLeft = 1.0f;
    public float marginTop = 1.0f;

    // Update is called once per frame
    void Update()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        startRot = Quaternion.Euler(startRotVector);
        float top = 3.0f;

        for(int i = 0; i < 5; i++)
        {
            float left = -9.0f + offset;
            for (int j = 0; j < 5; j++)
            {
                GameObject go = Instantiate(prefab, new Vector3(left, top, -1), startRot);
                go.transform.SetParent(cubeParent);
                left += sizeOfPrefab + marginLeft;
            }
            top -= sizeOfPrefab + marginTop;
        }

        gest = new OneTouchRotateGestureRecognizer();
        gest.Updated += callback;
        FingersScript.Instance.AddGesture(gest);

    }

    void callback(GestureRecognizer gesture,ICollection<GestureTouch> touches)
    {
        bool val;
        if(inCenterObject == null)
        {
            val = true;
        }
        else
        {
            val = !inCenterObject.isMoving;
        }
        
        if(gesture.State == GestureRecognizerState.Executing && !isOnScreen && val)
        {
            Debug.Log(gesture.DeltaY);
            Vector3 pos = cubeParent.transform.position;
            if (pos.y < 0 && gesture.DeltaY < 0)
            {
                return;
            }
            if(pos.y > 6 && gesture.DeltaY > 0)
            {
                return;
            }
            cubeParent.transform.Translate(new Vector3(0, sensitivity * gesture.DeltaY, 0));
        }

        if (gesture.State == GestureRecognizerState.Executing && isOnScreen)
        {
            
            bool dir = false;
            if (inCenterObject.isRotating)
            {
                return;
            }
            if(Mathf.Abs(gesture.DeltaX) < Mathf.Abs(gesture.DeltaY))
            {
                dir = true;
            }
            if (!dir)
            {
                if (gesture.DeltaX < 0)
                {
                    //inCenterObject.RotateCube(new Vector3(0, 1, 0), 1);
                }
                else
                {

                    inCenterObject.StartRotaion(0);
                    //inCenterObject.RotateCube(new Vector3(0, 1, 0), -1);

                }
            }
            else
            {
                if (gesture.DeltaY < 0 && dir)
                {
                    //inCenterObject.RotateCube(new Vector3(1, 0, 0), 1);
                }
                else
                {
                    //inCenterObject.RotateCube(new Vector3(1, 0, 0), -1);

                }
            }
            

           
        }
    }

    


}
