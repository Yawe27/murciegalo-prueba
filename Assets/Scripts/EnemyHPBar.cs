using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHPBar : MonoBehaviour
{
    public Image enemyHPBar;

    EnemyController enemyHP;

    
    // Start is called before the first frame update
    //void Start()
    //{
    //    enemyHP = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    enemyHPBar.fillAmount = enemyHP.actualHp;
    //}
}
