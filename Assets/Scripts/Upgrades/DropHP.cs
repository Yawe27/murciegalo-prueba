using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHP : MonoBehaviour
{
    PlayerStatsController playerstats;
    public GameObject textCD;

    // Start is called before the first frame update
    void Start()
    {
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();

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
            playerstats.maxHP += 1;
            Destroy(this.gameObject);
        }
    }
}
