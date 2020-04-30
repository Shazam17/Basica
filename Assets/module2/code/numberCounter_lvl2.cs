using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class numberCounter_lvl2 : MonoBehaviour
{

    public int counter = 0;
    public int targerCount = 3;

    public RectTransform startSpawnPoint;
    public GameObject spawningObject;
    public Transform parent;
    public AudioSource aS;


    void Start()
    {
        aS = GetComponent<AudioSource>();
        int randNumber = Random.Range(1, 10);

        Sprite textureTemp = Resources.Load<Sprite>("lvl2_2_basket/" + randNumber.ToString()) as Sprite;
        GetComponent<Image>().sprite = textureTemp;

        targerCount = randNumber;

        int n = randNumber;
        if(randNumber < 10)
        {
            n = randNumber + 1;
        }
        if (randNumber < 5)
        {
            n = randNumber + 2;
        }

        Vector3 move = new Vector3(100, 0,0);
        for (int i = 0; i < n && i < 5; i++)
        {
            var go = Instantiate(spawningObject, startSpawnPoint);
            go.transform.SetParent(parent);
            startSpawnPoint.localPosition += move ;
        }

        startSpawnPoint.localPosition += new Vector3(0, -80, 0);
        startSpawnPoint.localPosition += new Vector3(-500,0 ,0);
        for (int i = 5; i < n; i++)
        {
            var go = Instantiate(spawningObject, startSpawnPoint);
            go.transform.SetParent(parent);
            startSpawnPoint.localPosition += move;
        }
    }

    IEnumerator ToNextLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("numbersLevel2");
           
    }

    public void EndLevel()
    {
        if (counter == targerCount)
        {
            aS.PlayOneShot(OpenGteets.GetGreet());
            StartCoroutine(ToNextLevel());
        }
        else
        {
            aS.PlayOneShot(OpenGteets.GetDis());
        
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        counter += other.GetComponent<dragNumber>().weight;
        
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        counter -= other.GetComponent<dragNumber>().weight;
        Debug.Log("letter goes");
    }


}
