using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class autoScalingScript : MonoBehaviour
{

    GridLayoutGroup grid;
    public int constanta = 100;
    // Start is called before the first frame update
    void Start()
    {
        grid = GetComponent<GridLayoutGroup>();

 
        float kX = Display.displays[0].systemWidth / 2560.0f;
        float kY = Display.displays[0].systemHeight / 1440.0f;
        Debug.Log("new session");
        Debug.Log(kX);
        Debug.Log(kY);



        grid.cellSize = new Vector2(constanta * kX * 1.53f, constanta * kY);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
