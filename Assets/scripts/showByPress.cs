using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showByPress : MonoBehaviour
{



    private byte timesPressed = 0;

    public void onPress()
    {
        timesPressed++;
        if(timesPressed == 2)
        {
            moveToCenter mv = GetComponent<moveToCenter>();
            mv.createNew();

            timesPressed = 0;
            Image img = GetComponent<Image>();

            letterController sh = GameObject.Find("gameManager").GetComponent<letterController>();
            //sh.showInCenter(img.sprite);
        }else if(timesPressed == 3)
        {
            Destroy(gameObject);
        }
        else
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            //audioSource.PlayOneShot();
            Debug.Log("play audio");
        }

       
    }

    public void SetDeleteble()
    {
        timesPressed = 2;
    }

    
}
