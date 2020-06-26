using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorPicker : MonoBehaviour
{
    public Color selectedColor;
    public selectColor lastSelect;
    public Color selectColor;

    public Image colorImage;

    void Start()
    {
        selectedColor = Color.white;
        colorImage.color = selectedColor;
    }
}
