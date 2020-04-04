using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class letterController : MonoBehaviour
{ 
    // Start is called before the first frame update
    public GameObject spawnObject;
    public GameObject disabledObject;
    private bool spawned = false;
   

    public void showInCenter(Sprite spr)
    {
        if (!spawned)
        {
            disabledObject.GetComponent<Image>().sprite = spr;
            disabledObject.SetActive(true);
            spawned = true;
        }

    }

    public void setSpawnedFalse()
    {
        //disabledObject.SetActive(false);
        disabledObject.SetActive(false);
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
