using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragFigure : MonoBehaviour, IDragHandler
{
    public string type;
    public bool enbld = true;
    public bool isActive = false;

    public void OnDrag(PointerEventData eventData)
    {
        if (enbld)
        {
            transform.position = eventData.position;
        }
    }

    public void OffDrag(Vector2 pos)
    {
        GetComponent<RectTransform>().localPosition = pos;
        enbld = false;
    }

    public void StopAct()
    {
        StartCoroutine(StopActivity());
    }

    IEnumerator StopActivity()
    {
        isActive = true;
        yield return new WaitForSeconds(1.5f);
        isActive = false;

    }

}
