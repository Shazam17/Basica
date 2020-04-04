using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class autoScaleParentCell : MonoBehaviour
{


    private GridLayoutGroup grid;
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rt = this.transform.GetComponent<RectTransform>();
        float width = rt.sizeDelta.x * rt.localScale.x;
        grid = GetComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(width, width / 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
