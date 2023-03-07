using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubosVidaPrototype : MonoBehaviour
{
    PlayerStatsController playerStatsController;
    // Start is called before the first frame update
    void Start()
    {
        playerStatsController = GameObject.Find("Player").GetComponent<PlayerStatsController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        playerStatsController.currentHP++;
        Destroy(this.gameObject);
    }
    //public void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(this.gameObject);
    //}
}
