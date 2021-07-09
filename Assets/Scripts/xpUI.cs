using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xpUI : MonoBehaviour
{

    Text exp;

    PlayerStatsController xpHUD; 


    // Start is called before the first frame update
    void Start()
    {
        exp = GetComponent<Text>();

        xpHUD = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();
    }

    // Update is called once per frame
    void Update()
    {
        exp.text = " " + xpHUD.xp + "/" + (int)xpHUD.xpRequired ;
    }
}
