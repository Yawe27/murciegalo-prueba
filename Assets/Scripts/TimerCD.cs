using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimerCD 
{
    [SerializeField]
    public float maxTime;
    float curTime;

    [SerializeField]
    public bool isFinished;

    public void Reset()
    {
        curTime = maxTime;

        isFinished = false;
    }

    public void Update()
    {
        curTime -= Time.deltaTime;
        if(curTime <= 0)
        {
            isFinished = true;
        }
    }

}
