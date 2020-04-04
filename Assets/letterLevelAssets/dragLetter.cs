using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dragLetter : MonoBehaviour
{

    private RectTransform rt;
    public float maxDistance;
    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetAxis("Fire1") > 0f)
        {

            float kX = Display.displays[0].systemWidth;
            float kY = Display.displays[0].systemHeight;
            Vector2 input = Input.mousePosition;
            Vector2 homogenousCoord = input / new Vector2(kX, kY);

            Canvas canvas = FindObjectOfType<Canvas>();
            float w = canvas.GetComponent<RectTransform>().rect.width;
            float h = canvas.GetComponent<RectTransform>().rect.height;
            //change basis to anchored left top

            homogenousCoord *= 2;
            homogenousCoord += new Vector2(-1,-1);
            

            homogenousCoord *= new Vector2(w/2,h/2);
            Vector2 diff = homogenousCoord - rt.anchoredPosition;
            if (diff.magnitude < maxDistance)
            {

                Vector2 resCoord = new Vector2(homogenousCoord.x, homogenousCoord.y);

                rt.anchoredPosition = resCoord;
                
            }
            
        }
    }
    
}
