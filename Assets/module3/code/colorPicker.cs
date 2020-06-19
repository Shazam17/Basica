using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorPicker : MonoBehaviour
{
    public Color selectedColor;
    public selectColor lastSelect;
    public Color selectColor;

    void Start()
    {
        selectedColor = Color.white;
    }
}
