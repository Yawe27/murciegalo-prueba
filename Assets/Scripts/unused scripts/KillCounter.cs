using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{
    LevelChanges Lc;
    public Text killtxt;
    PlayerStatsController pjDamage;

    // Start is called before the first frame update
    void Start()
    {
        Lc = GetComponent<LevelChanges>();
        pjDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();

    }

    // Update is called once per frame
    void Update()
    {
        killtxt.text = " " + Lc.Kills + " Kills";

        if(Lc.Kills == 20)
        {
            pjDamage.baseDamage += 5;
            killtxt.color = Color.blue;
        }else if(Lc.Kills == 40)
        {
            pjDamage.baseDamage += 15;
            killtxt.color = Color.red;
        }
        else if (Lc.Kills == 60)
        {
            pjDamage.baseDamage += 22;
            killtxt.color = Color.cyan;
        }
    }
}
