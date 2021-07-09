using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCDDown : MonoBehaviour
{
    PlayerMov playercd;

    // Start is called before the first frame update
    void Start()
    {
        playercd = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMov>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playercd.fireRate -= 0.02f;
        }
    }
}
