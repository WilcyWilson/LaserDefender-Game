using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
