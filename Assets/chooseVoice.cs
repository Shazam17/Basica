using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseVoice : MonoBehaviour
{

    public string file;
    public string level;
    public string module;
    // Start is called before the first frame update
    void Start()
    {
        string path = PlayerPrefs.GetString("voicePath");

        AudioClip clip = Resources.Load<AudioClip>(path + module + "/" +level +"/"+ file);
        GetComponent<AudioSource>().PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
