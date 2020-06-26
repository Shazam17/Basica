using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class selectColor : MonoBehaviour, IPointerClickHandler
{

    private Color color;
    public colorPicker picker;


    void Start()
    {
        color = GetComponent<Image>().color;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(picker.lastSelect != null)
        {
            picker.lastSelect.GetComponent<Image>().color = picker.lastSelect.color;
        }
        picker.lastSelect = this;
        GetComponent<Image>().color = picker.selectColor;
        picker.selectedColor = color;
        picker.colorImage.color = color;
    }
}
