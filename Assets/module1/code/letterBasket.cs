using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;






public class letterBasket : MonoBehaviour
{
    public char letter;
    public dragLetter[] letters;

    private AudioSource audioSource;
    private AudioClip intro;

    private string path;
    private SaveLoad save;
    private List<char> cLEts;
    public Text targetText;
    public GreetParticle particles;
    public static char GetRandomLetter()
    {
        int letterIndex = Random.Range(0, 31);

        char lettterChar = (char)(letterIndex + 1072);
      
        if(lettterChar == 'ы' || lettterChar == 'ь' || lettterChar == 'ъ' || lettterChar == 'ѐ') {
            return GetRandomLetter();
        }    
        return lettterChar;
    }

    public PlayStartAnimation handAnimation;

    public void PlayIntro()
    {
        StartCoroutine(playIntroDelayed());
    }

    public IEnumerator playIntroDelayed()
    {
        yield return new WaitForSeconds(0.4f);
        if (!audioSource.isPlaying)
        {
            handAnimation.PlayAnimation();
            audioSource.PlayOneShot(intro);
            foreach (var let in letters)
            {
                let.StartCoroutine(let.startLock());
            }
        }
    }
    
    public int lvl;
    public void RightButton()
    {
        if (lvl == 31)
        {
            PlayerPrefs.SetInt("lvl1_2_letter", 0);
        }
        else if (lvl == 25)
        {
            PlayerPrefs.SetInt("lvl1_2_letter", 29);
        }
        else
        {
            PlayerPrefs.SetInt("lvl1_2_letter", lvl + 1);

        }
        SceneManager.LoadScene("lettersLevel2");
    }

    public void LeftButton()
    {
        if (lvl == 0)
        {
            PlayerPrefs.SetInt("lvl1_2_letter", 31);
        }
        else if (lvl == 29)
        {
            PlayerPrefs.SetInt("lvl1_2_letter", 25);
        }
        else
        {
            PlayerPrefs.SetInt("lvl1_2_letter", lvl - 1);
           
        }
        SceneManager.LoadScene("lettersLevel2");
    }

    public void regenLevel()
    {
      
        SceneManager.LoadScene("lettersLevel2");

    }

    public void Start()
    {


        lvl = PlayerPrefs.GetInt("lvl1_2_letter");
     
   
        

        cLEts = new List<char>();
        for(int i = 0; i < 33; i++)
        {
            char lettterChar = (char)(1072 + i);
            if (lettterChar != 'ы' && lettterChar != 'ь' && lettterChar != 'ъ' && lettterChar != 'ѐ')
            {
                cLEts.Add((char)(1072 + i));
            }  
        }
        save = new SaveLoad(levels.letters);
        var letterChar = (char)(1072 + lvl);
        path = PlayerPrefs.GetString(playIntro.voicePath);
  
        AudioClip txt = Resources.Load<AudioClip>(path + "Буквы/Уровень 2/перетащи..на букву " + letterChar.ToString());
        letter = letterChar;
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(txt);
        intro = txt;
        cLEts.Remove(letter);
        List<dragLetter> letts = new List<dragLetter>(letters);
        var chsn = letts[Random.Range(0, letts.Count)];
        letts.Remove(chsn);
        targetText.text = letter.ToString().ToUpper();
        //Sprite textureTemp = Resources.Load<Sprite>("буквы_картинки/корзины/" + letterChar.ToString().ToUpper());
        //GetComponent<Image>().sprite = textureTemp;
        chsn.setLetter(letter);

        foreach(var l in letts)
        {
            char tLetter = cLEts[Random.Range(0, cLEts.Count)];
            cLEts.Remove(tLetter);
            l.setLetter(tLetter);
        }

    }

    bool falseTrigger = false;
    public AnimationClip fallInBoxClip;
    bool endLevel = false;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (letter == other.GetComponent<dragLetter>().letter && !falseTrigger)
        {
            //Perform animation
            particles.TurnParticleOn();
            GameObject targetImage = other.gameObject.transform.GetChild(0).gameObject;
            targetImage.transform.SetParent(gameObject.transform);
            targetImage.transform.SetAsFirstSibling();
            targetImage.GetComponent<Animator>().enabled = true;
            targetImage.GetComponent<Animator>().Play(fallInBoxClip.name);

         
            

            if (lvl == 31)
            {
                PlayerPrefs.SetInt("lvl1_2_letter", 0);
            }
            else if (lvl == 25)
            {
                PlayerPrefs.SetInt("lvl1_2_letter", 29);
            }
            else
            {
                PlayerPrefs.SetInt("lvl1_2_letter", lvl + 1);
            }

            save.AddP(letter.ToString());
            AudioClip clip = OpenGteets.GetGreet();
            audioSource = GetComponent<AudioSource>();
            audioSource.Stop();
            GetComponent<Animator>().Play("basket2True");
            foreach (var obj in letters)
            {
                StartCoroutine(obj.startLock());
            }
            audioSource.PlayOneShot(clip);
            endLevel = true;
            StartCoroutine(toNewLevel());
        }
        else
        {
            falseTrigger = true;
            save.AddM(letter.ToString());
            save.AddM(other.GetComponent<dragLetter>().letter.ToString());
            AudioClip clip = OpenGteets.GetDis();
            audioSource = GetComponent<AudioSource>();

            Handheld.Vibrate();
            GetComponent<Animator>().Play("letters2BasketFalse");
            audioSource.Stop();
            audioSource.PlayOneShot(clip);
            
            other.GetComponent<dragLetter>().GoBack();

            foreach (var obj in letters)
            {
                StartCoroutine(obj.startLock());
            }

        }


    }

    public void setFalseTrigger()
    {
        falseTrigger = false;
    }


    public IEnumerator toNewLevel()
    {
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("lettersLevel2");
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("letter goes");
    }
   
}
