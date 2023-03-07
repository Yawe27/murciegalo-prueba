using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpController : MonoBehaviour
{

    Rigidbody2D rb2D;
    Transform playerpos;

    // Start is called before the first frame update
    void Start()
    {
        playerpos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        rb2D = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.MovePosition(playerpos.position);
    }
}
