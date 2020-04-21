using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragFigure : MonoBehaviour, IDragHandler
{
    public string type;
    public bool enbld = true;

    public void OnDrag(PointerEventData eventData)
    {
        if (enbld)
        {
            transform.position = eventData.position;
        }
    }

    public void OffDrag(Vector2 pos)
    {
        GetComponent<RectTransform>().localPosition = pos;
        enbld = false;
    }
}
