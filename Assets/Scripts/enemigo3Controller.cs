using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo3Controller : MonoBehaviour
{
    
    public int damage; //daño al player

    public float speed;
    int randSpawnHp;
    
    public float actualHp = 10;

    Rigidbody2D rb2D;
    PlayerStatsController playerHP;
    GameObject player;
    public GameObject corazon;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector2 ab = player.transform.position - this.transform.position;

            rb2D.velocity = ab.normalized * speed;
        }
        if (actualHp <= 0)
        {
            randSpawnHp = Random.Range(0, 100);
            if(randSpawnHp > 30)
                Instantiate(corazon, this.transform.position, Quaternion.identity);
            
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            playerHP.currentHP -= damage;

            Destroy(this.gameObject);
            
        }

    }

    
}
