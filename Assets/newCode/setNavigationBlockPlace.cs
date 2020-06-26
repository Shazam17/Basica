using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setNavigationBlockPlace : MonoBehaviour
{ 

    void Start()
    {
        var rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(100, 100);
    }

    
}
