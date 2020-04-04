using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setDisabled : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void onPressDisable()
    {
        anim.SetBool("canGo", true);
        anim.Play("letterDisapear");



    }
        
    public void disableObject()
    {
    
        anim.SetBool("canGo", false);

        letterController sh = GameObject.Find("gameManager").GetComponent<letterController>();

        sh.setSpawnedFalse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
