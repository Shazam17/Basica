using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class pressOnColor_lvl1 : MonoBehaviour, IPointerClickHandler
{
    public string color;
    //private AudioSource aS;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //aS.PlayOneShot(aS.clip);
        Debug.Log(color + " clicked");
    }
}
