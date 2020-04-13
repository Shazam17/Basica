using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class clickToPaint : MonoBehaviour,IPointerClickHandler
{

    Texture2D txt;
    public Sprite inputImage;
    Image img;

    void paintRegion(Vector2 pos)
    {
        txt.SetPixel((int)pos.x, (int)pos.y, Color.blue);

        Vector2 posT = pos + new Vector2(0, 1);
        if (txt.GetPixel((int)posT.x, (int)posT.y).a != 1)
        {
            paintRegion(posT);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
       

    }

    // Start is called before the first frame update
    void Start()
    {
       
     
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            
        }    



    }
}
