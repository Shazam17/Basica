﻿using System.Collections;
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



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
