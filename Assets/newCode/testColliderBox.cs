using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testColliderBox : MonoBehaviour
{

    public string targetColor;
    public AudioSource audioSource;

    Vector2 initPos;
    public endLevel_lvl2 end;
    public bool matched = false;
    public Animator top;

  
    void OnTriggerEnter2D(Collider2D other)
    {
        SaveLoad save = new SaveLoad(levels.colors);
        DragColor_lvl2 drag = other.GetComponent<DragColor_lvl2>();

        if (targetColor == drag.color)
        {
            save.AddP(targetColor);

            matched = true;
            other.transform.SetParent(gameObject.transform);
            other.transform.SetAsFirstSibling();
            drag.lockColor();
            other.GetComponent<Animator>().enabled = true;
            other.GetComponent<Animator>().Play("fallInBox");
            top.gameObject.SetActive(true);
            top.Play("closeBox");
        }
        else
        {
            save.AddM(targetColor);
            save.AddM(drag.color);
            Hooks.GetInstance().PlayDis(audioSource);
            Handheld.Vibrate();
            drag.ToInit();
        }


        end.OnButtonPress();
    }

    bool lck = false;
    public void ToInit()
    {
        StartCoroutine(toInitPlace());

    }

    public void lockColor()
    {
        lck = true;
    }

    public IEnumerator lockProlog()
    {
        lck = true;
        yield return new WaitForSeconds(4.0f);
        lck = false;
    }
    private IEnumerator toInitPlace()
    {
        lck = true;
        var rect = GetComponent<RectTransform>();
        Vector2 diff = initPos - rect.anchoredPosition;
        while (diff.magnitude > 0.5f)
        {
            diff = initPos - rect.anchoredPosition;
            rect.anchoredPosition += diff.normalized;
            yield return new WaitForSeconds(0.01f);

        }
        rect.anchoredPosition = initPos;
        lck = false;
    }


}
