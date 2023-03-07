using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [Header ("Tiempo de Muerte")]
    public float deathTime;
    [Header("Velocidad")]
    public float speed;
    public int bulletDamage;

    

    
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(0, 1) * speed;

        Destroy(this.gameObject, deathTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);

            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            BosController bossHP = collision.gameObject.GetComponent<BosController>();
            bossHP.hp -= bulletDamage;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Araña"))
        {
            enemigo3Controller arañahp = collision.gameObject.GetComponent<enemigo3Controller>();
            arañahp.actualHp -= bulletDamage;
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Cubo"))
        {

            Destroy(collision.gameObject);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Boss"))
    //    {
    //        BosController bossHP = collision.gameObject.GetComponent<BosController>();
    //        bossHP.hp -= bulletDamage;
    //        Destroy(this.gameObject);
    //    }
    //}

}
