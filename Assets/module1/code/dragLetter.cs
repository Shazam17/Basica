using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // Required when using Event data.

public class dragLetter : MonoBehaviour,IDragHandler
{
    public char letter;
    public Transform pos;

    public void Start()
    {
        char randomLetter = letterBasket.GetRandomLetter();
        Object[] txts = Resources.LoadAll("lvl1_2_images/" + randomLetter.ToString(), typeof(Sprite));
        Debug.Log(randomLetter);
        GetComponent<Image>().sprite = txts[Random.Range(0, txts.Length)] as Sprite;
        letter = randomLetter;
    }

    public void setLetter(char letter)
    {
       
        Object[] txts = Resources.LoadAll("lvl1_2_images/" + letter.ToString(),typeof(Sprite));
        Debug.Log("setting letter " + letter);
        Debug.Log(txts.Length);
        GetComponent<Image>().sprite = txts[Random.Range(0,txts.Length)] as Sprite;
        this.letter = letter;
    }

    public void ReturnToInitial()
    {
        transform.position = pos.transform.position;
 
    }

    public void OnDrag(PointerEventData eventData)
    {

            transform.position = eventData.position;

    }
     
}
