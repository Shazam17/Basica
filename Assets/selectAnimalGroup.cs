using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selectAnimalGroup : MonoBehaviour
{

    public int value;

    public createLevel1 level;
    public void Select()
    {
        level.LoadAnimals(value);
    }
}
