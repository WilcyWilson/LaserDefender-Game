using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayer2Status : MonoBehaviour
{
    GameObject obj;

    private void Start()
    {
        obj = GameObject.Find("Player2");
        if (!obj)
        {
            Destroy(gameObject);
            return;
        }
    }
}
