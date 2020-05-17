using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AudioOnPress : MonoBehaviour,IPointerClickHandler
{
    public string module;
    public string level;
    public string fileName;

    private AudioSource audioSource;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioSource.clip);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        string path = PlayerPrefs.GetString("voicePath");
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>(path + module + "/" + level + "/" + fileName) as AudioClip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
