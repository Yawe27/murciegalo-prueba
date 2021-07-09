using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCDown : MonoBehaviour
{
    PlayerMov playercd;
    public GameObject textCD;
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        playercd = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMov>();
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(textCD, this.transform.position, Quaternion.identity);
            playercd.fireRate -= 0.02f;
            
            Destroy(this.gameObject);
        }
    }
}
