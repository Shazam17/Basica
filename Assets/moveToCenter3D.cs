using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;

public class moveToCenter3D : MonoBehaviour
{
    public Vector3 initialPosition;
    public Vector3 dest;
    public Vector3 dir;

    public Vector3 rotAxis;
    public float rotDir;


    public bool isMoving = false;
    public bool isRotating = false;
    public bool isInCenter = false;

    public float rotationSpeed = 10.0f;
    public float rotated = 0.0f;
    public float targetRotation = 90.0f;
    // Update is called once per frame

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void SetAnim(bool val)
    {
        anim.SetBool("isInCenter",val);

    }

    void Update()
    {
        if (isMoving)
        {
            Vector3 diff = dest - transform.position;
            if(diff.magnitude < 0.1f)
            {
                isMoving = false;
                
                
                transform.position = dest;
            }
            else
            {


                transform.position += dir * 0.1f;
            }
        }
        if (false)
        {
            if(rotated < targetRotation)
            {
                rotated += rotationSpeed * Time.deltaTime;
                transform.Rotate(rotAxis, rotationSpeed * Time.deltaTime * rotDir);
            }
            else
            {
                rotated = 0;
                isRotating = false;
                //transform.position = dest;
            }
        }
    }

    public void StopRotations()
    {
        anim.SetBool("rotateToIdle", false);
        anim.SetBool("rotateCube", false);
        isRotating = false;
    }

    public void StartRotaion(int dir)
    {
        if (!isRotating)
        {
            isRotating = true;
            anim.SetBool("rotateCube", true);
            //Rotate(dir);
        }
      
    }



    public void SetIdle()
    {
        //anim.Play("idleInCenter");

    }

    public void RotateUp()
    {
        anim.Play("rotateUp");
    }

    public void RotateDown()
    {
        anim.Play("rotateDown");
    }

    public void RotateRight()
    {
        anim.Play("rotateRight");
    }

    public void RotateLeft()
    {
        anim.Play("rotateLeft");
    }

    public void RotateLeft2()
    {
        anim.SetInteger("directionOfRotation", 2);
    }
    public void ReturnRotateLeft()
    {
        RotateLeft();
        //anim.SetInteger("directionOfRotation", -2);
    }

    public void Rotate(cS dir)
    {
        switch (dir)
        {
            case cS.idle:
            isRotating = true;
                Debug.Log("move to idlee");
                anim.SetBool("rotateToIdle", true);
                SetIdle();
                break;

            case cS.right:
                isRotating = true;

                RotateRight();
                break;

            case cS.left:
                isRotating = true;

                RotateLeft();
                break;
            case cS.left2:
                isRotating = true;

                RotateLeft2();
                break;
            case cS.retLeft:
                isRotating = true;

                ReturnRotateLeft();
                break;

            default:
                SetIdle();
                break;
        }
    }

    public void RotateCube(Vector3 axis,float val)
    {
        isRotating = true;
        rotAxis = axis;
        rotDir = val;
    }
}
