using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationStart : MonoBehaviour
{

    public AnimationClip clip;
    public AnimationClip pointerClip;
    public Animator pointerAnimator;

    void Start()
    {
        PlayStart();
    }

    public void PlayStart()
    {
        GetComponent<Animator>().Play(clip.name);
        pointerAnimator.Play(pointerClip.name);
    }


}
