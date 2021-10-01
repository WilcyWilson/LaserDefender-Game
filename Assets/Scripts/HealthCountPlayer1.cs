using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCountPlayer1 : MonoBehaviour
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
        healthText.text = player.GetHealthCount().ToString();
    }
}
