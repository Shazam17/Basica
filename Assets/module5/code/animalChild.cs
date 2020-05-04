using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class animalChild : MonoBehaviour, IDragHandler
{
    public string type;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}
