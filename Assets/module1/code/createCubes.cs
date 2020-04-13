using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public enum cS
{
    idle,
    left,
    left2,
    right,
    right2,
    retLeft,
    retRight,
    up,
    down
}
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





    public cS state = cS.idle;

    cS canRotate(cS dir,ref bool flag)
    {
        
        if((dir == cS.left || dir == cS.right || dir == cS.up || dir == cS.down) && state == cS.idle)
        {
            flag = true;
            state = dir;
            return dir;
        }
        

        if(state == cS.up && dir == cS.down)
        {
            flag = true;
            state = cS.idle;
            return cS.idle;
        }

        if (state == cS.down && dir == cS.up)
        {
            flag = true;
        
            state = cS.idle; 
            return cS.idle;
        }

        if(state == cS.left && dir == cS.right)
        {
            flag = true;

            state = cS.idle;
            return cS.idle;
        }

        if (state == cS.right && dir == cS.left)
        {
            flag = true;

            state = cS.idle;
            return cS.idle;
        }

        if(state == cS.left && dir == cS.left)
        {
            flag = true;

            state = cS.left2;
            return cS.left2;
        }

        if (state == cS.left2 && dir == cS.right)
        {
            flag = true;

            state = cS.left;
            return cS.retLeft;
        }
        flag = false;
        return cS.idle;
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
            inCenterObject.GetComponent<Animator>().enabled = false;
            inCenterObject.transform.Rotate(new Vector3(0, 1, 0), -gesture.DeltaX * 0.5f);
            inCenterObject.transform.Rotate(new Vector3(1, 0, 0), gesture.DeltaY * 0.5f);

            return;
            
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
                    bool flag = false;
                    cS dirP = canRotate(cS.left, ref flag);
                    if (flag)
                    {
                        inCenterObject.Rotate(dirP);

                    }
                    //inCenterObject.RotateCube(new Vector3(0, 1, 0), 1);
                }
                else
                {
                    bool flag = false;
                    cS dirP = canRotate(cS.right, ref flag);
                    if (flag)
                    {
                        inCenterObject.Rotate(dirP);

                    }
                    //inCenterObject.RotateCube(new Vector3(0, 1, 0), -1);

                }
            }
            else
            {
                if (gesture.DeltaY < 0 && dir)
                {
                    inCenterObject.RotateDown();

                    //inCenterObject.RotateCube(new Vector3(1, 0, 0), 1);
                }
                else
                {
                    inCenterObject.RotateUp();

                    //inCenterObject.RotateCube(new Vector3(1, 0, 0), -1);

                }
            }
            

           
        }
    }

    


}
