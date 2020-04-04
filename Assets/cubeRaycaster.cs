using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeRaycaster : MonoBehaviour
{

  

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                //
                // = true;
                moveToCenter3D mv = hit.collider.GetComponent<moveToCenter3D>();
                if (mv.isRotating)
                {
                    return;
                }
                if (mv.isInCenter)
                {
                    Vector3 pos = hit.transform.position;
                    Vector3 initPlace = mv.initialPosition;
                    Vector3 dir = initPlace - pos;

                    mv.dir = dir.normalized;
                    mv.dest = initPlace;
                    mv.isMoving = true;
                    mv.isInCenter = false;
                    mv.SetAnim(false);
                    GetComponent<createCubes>().isOnScreen = false;
                    
                }
                else if(!GetComponent<createCubes>().isOnScreen)
                {
                    GameObject.Find("gameManager").GetComponent<createCubes>().inCenterObject = hit.collider.GetComponent<moveToCenter3D>();
                    GetComponent<createCubes>().isOnScreen = true;

                    Vector3 pos = hit.transform.position;
                    Vector3 destination = new Vector3(0, 0, -4);
                    Vector3 dir = destination - pos;

                    mv.initialPosition = hit.transform.position;
                    mv.dir = dir.normalized;
                    mv.dest = destination;
                    mv.isInCenter = true;
                    mv.SetAnim(true);

                    mv.isMoving = true;
                }

            }
        }
    }
}
