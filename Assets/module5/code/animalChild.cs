using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class animalChild : MonoBehaviour, IDragHandler
{
    public string type;

    void Awake()
    {
        Sprite[] sprs = Resources.LoadAll<Sprite>("животные_картинки/Уровень 2/нет");
        GetComponent<Image>().sprite = sprs[Random.Range(0, sprs.Length)];
        type = sprs[Random.Range(0, sprs.Length)].name;
    }

    public void SetParent(string type)
    {
        this.type = type;
        Sprite spr = Resources.Load<Sprite>("животные_картинки/Уровень 2/нет/" + type);
        Debug.Log("Setting the child:" + type + " : " + "животные_картинки/Уровень 2/нет/" + type);
        GetComponent<Image>().sprite = spr;
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }
}
