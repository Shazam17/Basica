using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setBackground : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string path = PlayerPrefs.GetString("backPath");
        Texture2D txt = (Texture2D)Resources.Load(path);
        Rect rect = new Rect(0, 0, txt.width, txt.height);
        GetComponent<SpriteRenderer>().sprite = Sprite.Create(txt,rect,new Vector2(0.5f, 0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
