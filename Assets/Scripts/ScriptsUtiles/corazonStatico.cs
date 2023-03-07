using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corazonStatico : MonoBehaviour
{
    public int health;
    public float speed;
    PlayerStatsController playerhp;
    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        //playerhp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();
        rb2d = this.GetComponent<Rigidbody2D>();

        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStatsController playerhp = collision.GetComponent<PlayerStatsController>();
            if(playerhp.currentHP < playerhp.maxHP)
                if (playerhp.currentHP + health <= playerhp.maxHP)
                playerhp.currentHP += health;


            Destroy(this.gameObject);
        }
    }
}
