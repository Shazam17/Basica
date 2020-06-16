using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpScript : MonoBehaviour
{
    public Text equation;

    public Text[] variants;
    public level_navigator_mainMenu navigator;

    public string target;
    public string scene;
    void Start()
    {
        GenetaratePopUp();
        
    }

    public IEnumerator StartOffTimer()
    {
        yield return new WaitForSeconds(10.0f);
        navigator.ClosePopUp();
    }

    public void OnBlurPress()
    {
        navigator.ClosePopUp();
    }
    

    int RandomWithout(int n)
    {
        int rand = Random.Range(1, 20);
        if(rand == n)
        {
            return RandomWithout(n);
        }
        return rand;
    }

    public void GenetaratePopUp()
    {
        StartCoroutine(StartOffTimer());
        int n1 = Random.Range(1, 9);
        int n2 = Random.Range(1, 9);

        int sum = n1 + n2;
        target = sum.ToString();
        equation.text = $"{n1} + {n2} = "; 


        for(int i = 0; i < variants.Length; i++)
        {
            variants[i].text = RandomWithout(sum).ToString();
        }

        variants[Random.Range(0, variants.Length)].text = sum.ToString();

    }

    public void DisablePopUp()
    {
        navigator.DisablePopUp();
    }

    public void Answer(string variant)
    {
        if (variant == target)
        {
            navigator.Navigate(scene);
        }
        else
        {
            navigator.ClosePopUp();
        }
    }
}
