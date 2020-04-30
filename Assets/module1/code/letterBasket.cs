using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class letterBasket : MonoBehaviour
{
    public char letter;

    AudioSource aS;

    public dragLetter[] letters;

    private string path;

    public static char GetRandomLetter()
    {
        int letterIndex = Random.Range(0, 31);
        char lettterChar = (char)(letterIndex + 1072);
        //Debug.Log(lettterChar);
        if(lettterChar == 'ф' || lettterChar == 'ч' || lettterChar == 'ц'  || lettterChar == 'ь' || lettterChar == 'р' || lettterChar == 'ы')
        {
            return GetRandomLetter();
        }
        return lettterChar;
    }

    

    public void Start()
    {
        var letterChar = GetRandomLetter();
        path = PlayerPrefs.GetString(playIntro.voicePath);
        Debug.Log(path + "lvl1_2_introSounds/перетащи..на букву " + letterChar.ToString());
        AudioClip txt = Resources.Load<AudioClip>(path + "lvl1_2_introSounds/перетащи..на букву " + letterChar.ToString()) as AudioClip;
        letter = letterChar;
        aS = GetComponent<AudioSource>();
        aS.PlayOneShot(txt);

        Sprite textureTemp = Resources.Load<Sprite>("lvl1_2_baskets/" + letterChar.ToString().ToUpper()) as Sprite;
        GetComponent<Image>().sprite = textureTemp;
        int index = Random.Range(0, letters.Length);

        letters[index].setLetter(letter);

    }
    bool endLevel = false;
    void OnTriggerEnter2D(Collider2D other)
    {
      if(letter == other.GetComponent<dragLetter>().letter)
        {
            AudioClip clip = OpenGteets.GetGreet();
            aS = GetComponent<AudioSource>();
            aS.PlayOneShot(clip);
            endLevel = true;

        }
        else
        {
            AudioClip clip = OpenGteets.GetDis();
            aS = GetComponent<AudioSource>();
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(clip);
            }
            other.GetComponent<dragLetter>().ReturnToInitial();
        }
    }

    void Update()
    {
        if(!aS.isPlaying && endLevel)
        {
            SceneManager.LoadScene("lettersLevel2");

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("letter goes");
    }
   
}
