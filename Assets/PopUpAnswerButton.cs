using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpAnswerButton : MonoBehaviour
{
    public PopUpScript script;
   public void OnPress()
    {
        string answer = GetComponentInChildren<Text>().text;
        script.Answer(answer);
    }

}
