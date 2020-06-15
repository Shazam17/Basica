using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blurApearScript : MonoBehaviour
{

    Material mat;

    



    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Image>().material;
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
