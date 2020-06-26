using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseDrawer : MonoBehaviour
{

    public GameObject[] paintings;



    // Start is called before the first frame update
    void Start()
    {
        var index = PlayerPrefs.GetInt("paintType");
        var chsn = paintings[index];
        var go = Instantiate(chsn, this.transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
