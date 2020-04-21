using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class selectColor : MonoBehaviour, IPointerClickHandler
{

    public Color color;
    public colorPicker picker;
    public void OnPointerClick(PointerEventData eventData)
    {
        picker.selectedColor = color;
    }
}
