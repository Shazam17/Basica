using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class centerLower : MonoBehaviour
{

    public GridLayoutGroup parentGrid;
    GridLayoutGroup selfGrid;
    // Start is called before the first frame update
    void Start()
    {
        selfGrid = GetComponent<GridLayoutGroup>();
        RectTransform rt = parentGrid.transform.GetComponent<RectTransform>();
        float width = rt.sizeDelta.x * rt.localScale.x;
        selfGrid.padding.left = (int)(width / 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
