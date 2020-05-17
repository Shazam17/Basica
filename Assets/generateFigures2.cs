using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class generateFigures2 : MonoBehaviour
{


    public dragFigure figure;

    public containerFigure[] containers;

    // Start is called before the first frame update
    void Start()
    {
        Sprite[] arr = Resources.LoadAll<Sprite>("фигуры_картинки/Уровень 2/формы");

        Sprite[] items = Resources.LoadAll<Sprite>("фигуры_картинки/Уровень 2/предметы");

     

        List<Sprite> forms = new List<Sprite>();
        forms.AddRange(arr);




        for(int i = 0; i < 3; i++)
        {
            int r1 = Random.Range(0, forms.Count);
            containers[i].GetComponent<Image>().sprite = forms[r1];
            containers[i].type = forms[r1].name;
            forms.Remove(forms[r1]);
        }

        int rFigure = Random.Range(0, containers.Length);
        string targetFigureName = containers[rFigure].type;

        List<Sprite> filteredItems = new List<Sprite>();
        foreach (var item in items)
        {
            if (item.name.Contains(targetFigureName))
            {
                filteredItems.Add(item);
            }
        }

        int randomFromItems = Random.Range(0, filteredItems.Count);
        figure.GetComponent<Image>().sprite = filteredItems[randomFromItems];
        figure.type = targetFigureName;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
