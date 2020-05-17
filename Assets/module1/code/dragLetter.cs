using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class dragLetter : MonoBehaviour,IDragHandler
{
    public char letter;
    public Transform pos;
    private Vector2 initPlace;
    public void Awake()
    {
        initPlace = GetComponent<RectTransform>().anchoredPosition;
        
    
    }

    public void setLetter(char l)
    {   
        Sprite[] txts = Resources.LoadAll<Sprite>("буквы_картинки/Уровень 2/" + l.ToString());
        GetComponent<Image>().sprite = txts[Random.Range(0,txts.Length)] ;
        letter = l;
    }
  

    public void OnDrag(PointerEventData eventData)
    {
        if (!lck)
        {
            transform.position = eventData.position;
        }
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
}
