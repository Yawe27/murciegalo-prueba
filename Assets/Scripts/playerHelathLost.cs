using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHelathLost : MonoBehaviour
{
    public int bloodLost = 2;
    public TimerCD timer;

    [Range (0,1)]
    public float percent;

    PlayerStatsController hpPlayer;
    
    PlayerMov cdPlayer;

    // Start is called before the first frame update
    void Start()
    {
        timer.maxTime = 4;
        hpPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();
        
        cdPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMov>();
    }

    // Update is called once per frame
    void Update()
    {
        timer.Update();

        if (timer.isFinished)
        {
            hpPlayer.currentHP -= bloodLost;
            timer.Reset();
        }
        

        
    }

   
}
