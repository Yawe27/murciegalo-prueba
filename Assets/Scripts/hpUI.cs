using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpUI : MonoBehaviour
{
    Text hpHUD;

    PlayerStatsController hpPlayer;


    // Start is called before the first frame update
    void Start()
    {
        hpPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();

        hpHUD = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        hpHUD.text = "" + hpPlayer.currentHP;
    }
}
