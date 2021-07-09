using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class BosController : MonoBehaviour
{
    public int hp;
    public int randAttack;

    Animator hurt;

    

    public float maxtime;
    float curTime;
    

    public Transform[] spawners;
    public Transform webShotPosition;
    
    public GameObject araña;
    public GameObject webShot;
    public GameObject jugador;
    public GameObject RandomSpawner;
    public Image fill;

    public TimerCD timer;

    [Range (0,1)]
    public float percent;

    PlayerStatsController player;
    
    // Start is called before the first frame update
    void Start()
    {
        hurt = this.gameObject.GetComponent<Animator>();
        fill.fillAmount = hp;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        curTime -= Time.deltaTime;
        timer.Update();

        //fases Boss
        if(hp <= 500)
        {
            timer.maxTime = 1.8f; //Spawner cd
            maxtime = 1.5f;
        }
        if (hp <= 300)
        {
            //fase2 = true;
            timer.maxTime = 1f;
            maxtime = 1f; 
        }
        if(hp <= 0)
        {
            RandomSpawner.SetActive(true);
            Destroy(this.gameObject);
        }


        if (timer.isFinished)
        {
            spawner();

            timer.Reset();
        }
        if(curTime <= 0)
        {
            basicAttack();

            curTime = maxtime;
        }
    }

    public void spawner()
    {

        int randspawners = Random.Range(0, spawners.Length);

       
        if (timer.isFinished)
        {
            Instantiate(araña, spawners[randspawners].position, Quaternion.identity);
        }
    }

    void basicAttack()
    {
         Instantiate(webShot, webShotPosition.position, Quaternion.identity);
    }

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        player.currentHP -= 20;
    //    }
        
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.currentHP -= 20;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hurt.SetBool("isHurt", true);
        }
    }
}
