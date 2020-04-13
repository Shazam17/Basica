using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class paintRegion : MonoBehaviour, IPointerClickHandler
{
    Image img;
    public string color;
    public void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        img.color = Color.red;
    }
}
