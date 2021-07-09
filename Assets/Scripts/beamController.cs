using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamController : MonoBehaviour
{
    public float beamDamage;
    Transform playerPos;

    EnemyController enemyhp;

    // Start is called before the first frame update
    void Start()
    {
        enemyhp = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerPos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyhp.actualHp -= beamDamage;
        }
    }
}
