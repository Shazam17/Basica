using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class container_figure_lvl3 : MonoBehaviour
{
    public string type;
    public void OnTriggerEnter2D(Collider2D other)
    {
        dragFigure fig = other.GetComponent<dragFigure>();
        if (type == fig.type)
        {
            fig.OffDrag(GetComponent<RectTransform>().localPosition);
        }
    }
}
