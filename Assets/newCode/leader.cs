using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leader : MonoBehaviour
{

    public GameObject fem;
    public GameObject mal;

    // Start is called before the first frame update
    void Start()
    {
        var v = Hooks.GetVoicePath();
        if (v.Equals("мужской/"))
        {
            var go = Instantiate(mal, transform);
            go.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }
        else
        {
            var go = Instantiate(fem, transform);
            go.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        }
        StartCoroutine(disaper());
    }


    public IEnumerator disaper()
    {
        yield return new WaitForSeconds(4.0f);
        var rt = GetComponent<Transform>();
        Debug.Log(rt.position.x);

        while (rt.position.x < 650)
        {
            rt.position += new Vector3(4f, 0,0);
            yield return new WaitForSeconds(0.01f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
