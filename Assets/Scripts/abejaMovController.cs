using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abejaMovController : MonoBehaviour
{
    public Transform[] movePos;

    Random rngMove;
    Rigidbody2D rb2D;

    public float hp = 10;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameVisible()
    {
        //rb2D.MovePosition(new Vector2(movePos[0].x, movePos[0].y ));
    }
}
