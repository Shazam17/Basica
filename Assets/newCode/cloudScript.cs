using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudScript : MonoBehaviour
{

    public int cloudAnimationType = 0;

    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetInteger("cloudType", cloudAnimationType);
    }

    void Update()
    {
        
    }
}
