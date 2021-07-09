using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webShotController : MonoBehaviour
{
    public int damage = 5;
    
    public float speed;
    Vector2 dir;
    Vector2 fuerza;
    //public float retroceso;

    Transform player;
    

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 b = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        dir = (b - (Vector2) transform.position).normalized;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //transform.LookAt(player);

    }

    // Update is called once per frame
    void Update()
    {
        //speed -= retroceso * Time.deltaTime;
        rb2d.velocity = dir * speed;
        //rb2d.AddForce(dir * speed);

        Destroy(this.gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStatsController playerhp = collision.GetComponent<PlayerStatsController>();
            playerhp.currentHP -= damage;

            Destroy(this.gameObject);
        }
    }

    
}
