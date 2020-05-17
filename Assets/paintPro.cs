using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class paintPro : MonoBehaviour, IPointerClickHandler
{
    Texture2D texture;
    public Texture2D Tload;
    public Texture2D t;

    Thread sub;
    float width;
    float height;
    Color col;

    int[ , ] imageMap;


    void Start()
    {
        var rect = GetComponent<RectTransform>();
        width = rect.rect.width;
        height = rect.rect.height;
        Debug.Log(width);
        Debug.Log(height);
        texture = new Texture2D(512,512);
        t = Tload;

        imageMap = new int[t.width, t.height];
        for(int i = 0; i < t.width; i++)
        {
            for(int j = 0; j < t.height; j++)
            {
                var col = t.GetPixel(j, i);
                if(col == Color.white)
                {
                    imageMap[i, j] = 0;
                }
                else
                {
                    imageMap[i ,j] = 1;
                }
            }
        }
       
        GetComponent<Image>().sprite = Sprite.Create(t,new Rect(0.0f, 0.0f, t.width, t.height), new Vector2(0.5f, 0.5f), 100.0f);
        //GetComponent<Image>().sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
    }




    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 localCursor;
        if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RectTransform>(), eventData.position, eventData.pressEventCamera, out localCursor))
            return;

       // Debug.Log("LocalCursor:" + localCursor);


        //var cord = new Vector2((int)localCursor.x + 150,(int)localCursor.y + 150) / new Vector2(300,300);
        var cord = new Vector2((int)localCursor.x + width / 2,(int)localCursor.y + height / 2) / new Vector2(width,height);


        colorPicker picker = GameObject.Find("colorPicker").GetComponent<colorPicker>();
        col = picker.selectedColor;
       // Debug.Log(cord);


        var pos = new Vector2Int((int)(cord.x * t.width), (int)(cord.y * t.height));
       

       FloodFill(pos,t.GetPixel(pos.x,pos.y),col);
        t.Apply();
       
    }


    int rep = 2;
    private void FloodFill(Vector2Int pt, Color targetColor, Color replacementColor)
    {
        Texture2D tex = new Texture2D(Tload.width, Tload.height, TextureFormat.PVRTC_RGBA4, false);
        Stack<Vector2Int> pixels = new Stack<Vector2Int>();
        var tColor = imageMap[pt.x,pt.y];
        pixels.Push(pt);
       
        while (pixels.Count > 0)
        {
        
            Vector2Int a = pixels.Pop();
            if (a.x < t.width && a.x > 0 &&
                    a.y < t.height && a.y > 0)//make sure we stay within bounds
            {

                if (imageMap[a.x,a.y] == tColor)
                {
                    imageMap[a.x, a.y] = rep;


                    pixels.Push(new Vector2Int(a.x - 1, a.y));
                    pixels.Push(new Vector2Int(a.x + 1, a.y));
                    pixels.Push(new Vector2Int(a.x, a.y - 1));
                    pixels.Push(new Vector2Int(a.x, a.y + 1));
                }
            }
        }
        byte[] l = new byte[t.height * t.width];
        for(int i = 0; i < Tload.width; i++)
        {
            for(int j= 0;j < Tload.height; j++)
            {
                if(imageMap[i , j] == 0)
                {
                    l[i * Tload.height +  j] = (0x00); 
                }
                if (imageMap[i, j] == 1)
                {
                    l[i * Tload.height + j] = (0x0ff);
                }
                if (imageMap[i, j] == 2)
                {
                    l[i * Tload.height + j] = (0xf);
                }
            }
        }
        tex.LoadRawTextureData(l);
        tex.Apply();
        GetComponent<Image>().sprite = Sprite.Create(t, new Rect(0.0f, 0.0f, t.width, t.height), new Vector2(0.5f, 0.5f), 100.0f);
    }
  

   
}
