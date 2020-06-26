﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class animalChild : MonoBehaviour, IDragHandler
{
    string path = "животные_картинки/Уровень 2/детёныши/";
    public string type;
    public bool lck = false;
    Vector2 initPos;

    void Awake()
    {
        Sprite[] sprs = Resources.LoadAll<Sprite>(path);
        GetComponent<Image>().sprite = sprs[Random.Range(0, sprs.Length)];
        type = sprs[Random.Range(0, sprs.Length)].name;
        //StartCoroutine(waitForAudio());
    }
    void Start()
    {
        initPos = GetComponent<RectTransform>().anchoredPosition;

    }
    public void SetParent(string type)
    {
        this.type = type;
        Sprite spr = Resources.Load<Sprite>(path + type);
        GetComponent<Image>().sprite = spr;
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!lck)
        {
            transform.position = eventData.position;
        }
    }

    public IEnumerator waitForAudio()
    {
        lck = true;
        yield return new WaitForSeconds(2.5f);
        lck = false;
    }

    public void toInit()
    {
        StartCoroutine(toInitPlace());
    }

    private IEnumerator toInitPlace()
    {
        lck = true;

        //
        var rect = GetComponent<RectTransform>();
        Vector2 diff = initPos - rect.anchoredPosition;
        while (diff.magnitude > 4.0f)
        {
            diff = initPos - rect.anchoredPosition;
            rect.anchoredPosition += diff.normalized * 5;
            yield return new WaitForSeconds(0.01f);

        }
        rect.anchoredPosition = initPos;
        lck = false;
    }
}
