using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createLevel5_2 : MonoBehaviour
{
    public animalContainer targetImage;
    public animalChild[] children;


    // Start is called before the first frame update
    void Start()
    {
        Sprite[] par = Resources.LoadAll<Sprite>("животные_картинки/Уровень 2/нормальные");
        List<Sprite> lPar = new List<Sprite>(par);

        Sprite target = lPar[Random.Range(0, lPar.Count)];
        targetImage.GetComponent<Image>().sprite = target;
        targetImage.type = target.name;

        children[Random.Range(0, children.Length)].SetParent(target.name);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
