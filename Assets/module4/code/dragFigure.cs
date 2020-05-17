using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragFigure : MonoBehaviour, IDragHandler
{
    public string type;
    public bool enbld = true;
    public bool isActive = false;
    private Vector2 initPlace;

    void Start()
    {
        initPlace = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (enbld && !lck)
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

    public void GoBack()
    {
        StartCoroutine(toInitPlace());
    }
    bool lck = false;
    private IEnumerator toInitPlace()
    {
        lck = true;

        GetComponent<RectTransform>().anchoredPosition = initPlace;
        yield return new WaitForSeconds(0.2f);
        lck = false;
    }
    IEnumerator StopActivity()
    {
        isActive = true;
        yield return new WaitForSeconds(1.5f);
        isActive = false;

    }

}
