using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xpPointController : MonoBehaviour
{
    Transform player;

    PlayerStatsController playerxp;

    Rigidbody2D rb2D;

    public float xpEnemy = 20f;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        playerxp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();

        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (player)
        {
            Vector2 ab = player.position-this.transform.position;

            rb2D.velocity = ab.normalized * speed;
        }
        
        

    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerxp.xp += xpEnemy;
            Destroy(this.gameObject);
        }
    }

}
