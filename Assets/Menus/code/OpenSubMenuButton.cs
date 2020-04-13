using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSubMenuButton : MonoBehaviour
{
    public void BackToSubMenu()
    {
        SceneManager.LoadScene("subMenuTemplate");
    }
}
