using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class centerObject : MonoBehaviour
{

    BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 touchPos = Input.mousePosition;
            Vector2 v2 = Camera.main.ScreenToWorldPoint(touchPos);
            if (boxCollider.OverlapPoint(v2))
            {

                letterController sh = GameObject.Find("gameManager").GetComponent<letterController>();
                sh.setSpawnedFalse();
                Destroy(gameObject);
            }
        }
    }
    /*
 * 
 *   Vector2 pos = rt.position;
        GameObject go = Instantiate(gameObject,pos , Quaternion.identity);
        RectTransform otherRt = go.GetComponent<RectTransform>();
        otherRt.sizeDelta = new Vector2(74,94);
        go.transform.SetParent(canvasTransform);

        float kX = Display.displays[0].systemWidth / 2560.0f;
        float kY = Display.displays[0].systemHeight / 1440.0f;
        Vector3 centr = new Vector3(kX / 2, kY / 2,0);

        Vector3 direction = centr - new Vector3(pos.x,pos.y,0);

        direction = direction.normalized;
        showByPress sh = go.GetComponent<showByPress>();
        sh.SetDeleteble();
        moveToCenter copys = go.GetComponent<moveToCenter>();
        copys.dir = direction;
        copys.isMoving = true;
 * 
 */

}

