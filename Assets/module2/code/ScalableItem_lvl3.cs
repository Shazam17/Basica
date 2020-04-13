using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // Required when using Event data.


public class ScalableItem_lvl3 : MonoBehaviour, IDragHandler
{

    public int weight = 1;


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }


}
