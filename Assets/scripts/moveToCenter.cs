using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveToCenter : MonoBehaviour
{


    public Transform canvasTransform;
    public Vector2 dir;
    public Vector2 centerTranform;
    public bool isMoving;

    private RectTransform sTransform;
    // Start is called before the first frame update
    void Start()
    {
        sTransform = GetComponent<RectTransform>();
        
    }

    void Update()
    {
        Debug.Log(sTransform.anchoredPosition);
        if(isMoving && sTransform.anchoredPosition != centerTranform)
        {
            sTransform.anchoredPosition += dir;
            dir = (centerTranform - sTransform.anchoredPosition).normalized;
            Vector2 tDir = sTransform.anchoredPosition - centerTranform;
            if(tDir.magnitude < 1.0)
            {
                sTransform.anchoredPosition = centerTranform;
                isMoving = false;
            }
        }
        else
        {
            isMoving = false;
        }
        
    }


    public void createNew()
    {
        Vector2 pos = sTransform.position;
        GameObject go = Instantiate(gameObject, pos, Quaternion.identity);
        RectTransform otherRt = go.GetComponent<RectTransform>();
        otherRt.sizeDelta = new Vector2(74, 94);
        go.transform.SetParent(canvasTransform);

        Canvas canvas = FindObjectOfType<Canvas>();

        float h = canvas.GetComponent<RectTransform>().rect.height;
        float w = canvas.GetComponent<RectTransform>().rect.width;

        Vector2 centr = new Vector3((int)w / 2, (int)h / 2);

        Vector2 direction = centr - pos;

        direction = direction.normalized;
        showByPress sh = go.GetComponent<showByPress>();
        sh.SetDeleteble();
        moveToCenter copys = go.GetComponent<moveToCenter>();
        copys.dir = direction;
        copys.isMoving = true;
        copys.centerTranform = centr;
        Debug.Log("Center");
        Debug.Log(centr);
        Debug.Log("direction");
        Debug.Log(direction);
    }
        
}
