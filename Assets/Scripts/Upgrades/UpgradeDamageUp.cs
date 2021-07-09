using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDamageUp : MonoBehaviour
{
    public GameObject textCD;
    PlayerStatsController playerstats;

    // Start is called before the first frame update
    void Start()
    {
        playerstats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    public void DamageUp()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(textCD, this.transform.position, Quaternion.identity);
            playerstats.currentDamage += 3;
            Destroy(this.gameObject);
        }
    }

}
