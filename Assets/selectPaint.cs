using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class selectPaint : MonoBehaviour
{
    public int type;


    public void OnPointerClick()
    {
        PlayerPrefs.SetInt("paintType", type);
        SceneManager.LoadScene("colorsLevel3");
    }
}
