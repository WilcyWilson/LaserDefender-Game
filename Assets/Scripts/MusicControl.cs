using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicControl : MonoBehaviour
{
    bool isMuted;
    MusicPlayer music;

    private void Start()
    {
        music = FindObjectOfType<MusicPlayer>();    
    }
    public void MusicToogle()
    {
        if (isMuted == false)
        {
            isMuted = true;
            music.GetComponent<AudioSource>().Stop();
            gameObject.GetComponent<TextMeshProUGUI>().text = "Music: Off";
        }
        else if (isMuted == true)
        {
            isMuted = false;
            music.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<TextMeshProUGUI>().text = "Music: On";
        }
    }
}
