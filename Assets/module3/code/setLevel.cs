using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setLevel : MonoBehaviour
{

    public ColorReciever_lvl2[] recievers;
    public DragColor_lvl2[] items;

    int getRandomWithout(int except , int max)
    {
        int random = Random.Range(0, max);
        if(random == except)
        {
            return getRandomWithout(except, max);
        }
        return random;
    }

    int getRandomWithout(int except1, int except2, int max)
    {
        int random = Random.Range(0, max);
        if (random == except1 || random == except2 )
        {
            return getRandomWithout(except1, except2, max);
        }
        return random;
    }

    // Start is called before the first frame update
    void Start()
    {
        Object[] colors = Resources.LoadAll("цвета/цвета", typeof(Sprite));


        int recInd = Random.Range(0, recievers.Length);
        Sprite randomColorMain = colors[Random.Range(0, colors.Length)] as Sprite;
        ColorReciever_lvl2 randomItem = recievers[recInd];
        randomItem.GetComponent<Image>().sprite = randomColorMain;
        randomItem.color = randomColorMain.name;


        int colItemInd = Random.Range(0, items.Length);
        DragColor_lvl2 randomColorItem = items[colItemInd];
        Object[] colorItems = Resources.LoadAll("цвета/предметы/" + randomColorMain.name, typeof(Sprite));
        Debug.Log("цвета/предметы/" + randomColorMain.name);
        Sprite rSprite = colorItems[Random.Range(0, colorItems.Length)] as Sprite;
        randomColorItem.GetComponent<Image>().sprite = rSprite;
        randomColorItem.color = randomColorMain.name;


        int rec2Ind = getRandomWithout(recInd, recievers.Length);
        randomColorMain = colors[Random.Range(0, colors.Length)] as Sprite;
        randomItem = recievers[rec2Ind];
        randomItem.GetComponent<Image>().sprite = randomColorMain;
        randomItem.color = randomColorMain.name;

        int colItem2Ind = getRandomWithout(colItemInd, recievers.Length);
        randomColorItem = items[colItem2Ind];
        colorItems = Resources.LoadAll("цвета/предметы/" + randomColorMain.name, typeof(Sprite));
        Debug.Log("цвета/предметы/" + randomColorMain.name);
        rSprite = colorItems[Random.Range(0, colorItems.Length)] as Sprite;
        randomColorItem.GetComponent<Image>().sprite = rSprite;
        randomColorItem.color = randomColorMain.name;


        int rec3 = getRandomWithout(recInd, rec2Ind, recievers.Length);
        randomColorMain = colors[Random.Range(0, colors.Length)] as Sprite;
        randomItem = recievers[rec3];
        randomItem.GetComponent<Image>().sprite = randomColorMain;
        randomItem.color = randomColorMain.name;

        int col3 = getRandomWithout(colItemInd, colItem2Ind, recievers.Length);
        randomColorItem = items[col3];
        colorItems = Resources.LoadAll("цвета/предметы/" + randomColorMain.name, typeof(Sprite));
        Debug.Log("цвета/предметы/" + randomColorMain.name);
        rSprite = colorItems[Random.Range(0, colorItems.Length)] as Sprite;
        randomColorItem.GetComponent<Image>().sprite = rSprite;
        randomColorItem.color = randomColorMain.name;

    }
    
}
