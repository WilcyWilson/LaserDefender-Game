using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;
    GameObject obj;
    Player player;

    private void Start()
    {
        healthText = GetComponent<Text>();
        obj = GameObject.Find("Player");
        player = obj.GetComponent<Player>();
    }

    private void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
