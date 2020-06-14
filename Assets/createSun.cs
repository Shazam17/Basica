using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createSun : MonoBehaviour
{

    public GameObject sunPart;
    public GameObject parent;
    public int parts = 6;
    public float radius = 2;
    
    void Start()
    {
        float deg = 360.0f / parts;
        float initDeg = 0.0f;
        for(int i = 0; i < parts; i++)
        {
            var part = Instantiate(sunPart, parent.transform);
            //part.transform.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f);
            part.GetComponent<RectTransform>().anchoredPosition = (new Vector3(0, radius));
            part.transform.RotateAround(gameObject.transform.position, new Vector3(0, 0, 1), initDeg);

            if(i % 2 == 0)
            {
                part.GetComponent<Animator>().SetInteger("type", 0);
            }
            else
            {
                part.GetComponent<Animator>().SetInteger("type", 1);
            }
            initDeg += deg;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
