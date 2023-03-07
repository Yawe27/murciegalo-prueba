using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    //public float maxHp = 10;
    //public float actualHp;

    public float speed;

    public float daño; //daño recibido
    public int dmg; //daño al player
    
 
    public float deathTime;
    public Vector2 fuerza;

    Rigidbody2D rb2d;
    PlayerStatsController playerHP;
    LevelChanges levelc;
    GameObject player;


    public GameObject experiencia;

    public GameObject DropDamage;
    public GameObject DropHP;
    public GameObject DropCD;
    

    // Start is called before the first frame update
    void Start()
    {
        //maxHp = actualHp;

        rb2d = GetComponent<Rigidbody2D>();

        levelc = GameObject.FindGameObjectWithTag("Lc").GetComponent<LevelChanges>();
        //if (GameObject.FindGameObjectWithTag("Player"))
        //    Destroy(this.gameObject, 0);
        
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();

        player = GameObject.FindGameObjectWithTag("Player");

        //this.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //DeathEnemy();
        //if(actualHp < 0)
        //{
        //    levelc.Kills++;
        //    DropChance(); 
        //    this.gameObject.SetActive(false);
        //}

        rb2d.velocity += new Vector2(0, -1) * speed;
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Daño();

            this.gameObject.SetActive(false);

        }

        //if (collision.gameObject.CompareTag("Enemy"))
        //{
        //    Damaged(1);

        //    //this.gameObject.SetActive(false);
        //}

    }

    private void OnBecameInvisible()
    {
        
        this.gameObject.SetActive(false);
    }
    //private void DeathEnemy()
    //{
    //    if(actualHp <= 0)
    //    {
    //        //Instantiate(experiencia, transform.position, Quaternion.identity);
    //        levelc.Kills++;
    //        DropChance();
    //        Destroy(this.gameObject);
    //    }
    //}

    public void Damaged(float daño)
    {
        //actualHp -= daño;
    }

    public void Daño()
    {
        playerHP.currentHP -= dmg;
    }

    public void DropChance()
    {
        int randNum = Random.Range(1, 4);
        int rn = Random.Range(0, 100);

        if ((randNum == 1)&&( rn > 50))
        {
            Instantiate(DropDamage, this.transform.position, Quaternion.identity);
        }
        if ((randNum == 2)&& (rn > 75))
        {
            Instantiate(DropHP, this.transform.position, Quaternion.identity);
        }
        if ((randNum == 3)&& (rn > 80
            ))
        {
            Instantiate(DropCD, this.transform.position, Quaternion.identity);
        }
    }
}
