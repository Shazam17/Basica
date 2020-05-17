using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class DragColor_lvl2 : MonoBehaviour, IDragHandler
{
    public string color;
    Vector2 initPos;


    void Start()
    {
        initPos = GetComponent<RectTransform>().anchoredPosition;

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!lck)
        {
            transform.position = eventData.position;
        }
      
    }

    bool lck = false;
    public void ToInit()
    {
        StartCoroutine(toInitPlace());

    }

    private IEnumerator toInitPlace()
    {
        lck = true;
        
        GetComponent<RectTransform>().anchoredPosition = initPos;
        yield return new WaitForSeconds(0.2f);      
        lck = false;
    }

}
