using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class xpBarController : MonoBehaviour
{
    public PlayerStatsController xpManage;

    
    public Image fill;
    


    // Start is called before the first frame update
    void Start()
    {
        fill.fillAmount = 0;
        xpManage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();
    }

    // Update is called once per frame
    void Update()
    {
        filling();


        xpManage.Exp();
    }

    void filling()
    {
        fill.fillAmount += xpManage.xp / xpManage.xpRequired;
    }
}
