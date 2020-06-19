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
        PlayAnimation();
    }

   public void PlayAnimation()
    {
        GetComponent<Animator>().Play(startAnimation.name);

    }
}
