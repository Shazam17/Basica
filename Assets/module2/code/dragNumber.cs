using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragNumber : MonoBehaviour, IDragHandler
{

    public int weight = 1;
    private Vector2 initPlace;

    void Start()
    {
        initPlace = GetComponent<RectTransform>().anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!lck)
        {
            transform.position = eventData.position;

        }
    }

    public void LoadWithImage(int number)
    {
        Sprite spr = Resources.Load<Sprite>("цифры_картинки/Уровень 2/" + number.ToString());

        GetComponent<Image>().sprite = spr;
    }

    bool lck = false;
    public void ToInit()
    {
        StartCoroutine(toInitPlace());
    }
    private IEnumerator toInitPlace()
    {
        lck = true;

        GetComponent<RectTransform>().anchoredPosition = initPlace;
        yield return new WaitForSeconds(0.2f);
        lck = false;
    }
}
