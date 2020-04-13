using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class container_figure_lvl3 : MonoBehaviour
{
    public string type;
    public bool matched = false;
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collides");
        if (type == other.GetComponent<dragFigure>().type)
        {
            matched = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        matched = false;
    }
}
