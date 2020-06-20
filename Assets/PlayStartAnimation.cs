using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayStartAnimation : MonoBehaviour
{
    public AnimationClip startAnimation;
    //public AnimationClip clickClip;

    void Start()
    {
        StartCoroutine(Delayed());
    }
    IEnumerator Delayed()
    {
        yield return new WaitForSeconds(0.2f);

        PlayAnimation();
    }
    public void PlayAnimation()
    {
        transform.SetAsLastSibling();
        GetComponent<Animator>().Play(startAnimation.name);

    }
}
