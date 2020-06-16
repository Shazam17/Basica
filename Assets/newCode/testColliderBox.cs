using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testColliderBox : MonoBehaviour
{

    public Animator top;
    void OnTriggerEnter2D(Collider2D other)
    {
       
        DragColor_lvl2 drag = other.GetComponent<DragColor_lvl2>();
        other.transform.SetParent(gameObject.transform);
        other.transform.SetAsFirstSibling();
        other.GetComponent<DragColor_lvl2>().lockColor();
        other.GetComponent<Animator>().enabled = true;
        other.GetComponent<Animator>().Play("fallInBox");
        top.gameObject.SetActive(true);
        top.Play("closeBox");
    }

}
