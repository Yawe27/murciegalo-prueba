using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsController : MonoBehaviour
{
    
    public int currentHP;
    public int baseHP = 200;

    public int level;
    public int xp;
    public int xpRequired;

    public float baseDamage = 3;
    public float currentDamage;

    public GameObject levelPanel;

    [Range(0,1)]
    public float percent;

    xpBarController xpBar;
    PlayerMov playercd;
    

    // Start is called before the first frame update
    void Start()
    {

        currentHP = baseHP;

        level = 1;

        xp = 0;

        xpRequired = 60;

        currentDamage = baseDamage;
        

    }

    // Update is called once per frame
    void Update()
    {
        Exp();
    }

    public void LevelUp()
    {
        level++;

        
        levelPanel.SetActive(true);
        Time.timeScale = 0;
            

        //xpRequired += xpRequired * percent;

    }

    public void Exp()
    {
        if (xp >= xpRequired)
            LevelUp();

    }

    
    public void UpgradeDamage()
    {
        currentDamage += 2;
    }
    public void UpgradeShootSpeed()
    {
        playercd = GetComponent<PlayerMov>();

        playercd.fireRate -= 0.05f;
    }
}
