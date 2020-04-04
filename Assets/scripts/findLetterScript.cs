using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findLetterScript : MonoBehaviour
{


    Queue<char> lettersToFind;

    // Start is called before the first frame update
    void Start()
    {
        lettersToFind = new Queue<char>();
        lettersToFind.Enqueue('A');
        lettersToFind.Enqueue('B');
    }

    public char getNextLetter()
    {
        return lettersToFind.Peek();
    }

    public void removeLetter()
    {
        lettersToFind.Dequeue();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
