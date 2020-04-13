using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class DragColor_lvl2 : MonoBehaviour, IDragHandler
{
    public string color;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

}
