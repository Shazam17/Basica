using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorReciever_lvl2 : MonoBehaviour
{
    public string color;
    public bool matched;

    void OnTriggerEnter2D(Collider2D other)
    {
        DragColor_lvl2 drag = other.GetComponent<DragColor_lvl2>();
        if (drag.color.Equals(color))
        {
            matched = true;
        }
        Debug.Log("color in");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        matched = false;

    }
}
