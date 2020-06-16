using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRepeatTaskButton : MonoBehaviour
{

    void Start()
    {
        var rt = GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(-50, 60);
    }

}
