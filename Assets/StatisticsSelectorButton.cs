using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsSelectorButton : MonoBehaviour
{

    public int level;

    public statisticsSelector selector;

    public void OnPress()
    {
        selector.SelectLevel(level);
    }
}
