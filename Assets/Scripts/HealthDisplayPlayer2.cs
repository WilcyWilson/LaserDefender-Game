using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplayPlayer2 : MonoBehaviour
{
    Text healthText;
    GameObject obj;
    Player player;

    private void Start()
    {
        healthText = GetComponent<Text>();
        obj = GameObject.Find("Player2");
        if (!obj)
        {
            Destroy(gameObject);
            return;
        }
        player = obj.GetComponent<Player>();
    }

    private void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
