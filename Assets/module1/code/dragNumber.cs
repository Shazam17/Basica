using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragNumber : MonoBehaviour, IDragHandler
{

    public int weight = 1;

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void LoadWithImage(int number)
    {
        Sprite spr = Resources.Load<Sprite>("цифры_картинки/Уровень 2/" + number.ToString());

        GetComponent<Image>().sprite = spr;
    }

}
