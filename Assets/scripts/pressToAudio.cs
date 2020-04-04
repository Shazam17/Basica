using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressToAudio : MonoBehaviour
{

    public char letter;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void onPressButton()
    {
        Debug.Log("pressed");
        findLetterScript sh = GameObject.Find("gameManager").GetComponent<findLetterScript>();
        char nextLetter = sh.getNextLetter();
        if(nextLetter == letter)
        {
            Debug.Log("yepp this is that letter");
            sh.removeLetter();
        }
        else
        {
            Debug.Log("not true!!!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
