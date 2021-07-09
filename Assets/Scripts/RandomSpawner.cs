using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public float maxEnemies;


    public GameObject[] enemy;
    

    public Transform limiteIzq;
    public Transform limiteDer;

    //public float cd = 2f;
    public float counter = 0;
    public int randEnemy;

    public TimerCD timer;
   
    void Start()
    {
        counter = 0;
 
    }


    // Update is called once per frame
    void Update()
    {
        timer.Update();
        
     
        if (timer.isFinished)
        {
            cdSpawn();
            counter++;
            timer.Reset();
        }

    }

    void cdSpawn()
    {

        float randNumb = Random.Range(0.5f, 0.9f);

        randEnemy = Random.Range(0, 3);

        Vector3 pos = new Vector3(Random.Range(limiteIzq.position.x, limiteDer.position.x), limiteIzq.position.y, 0);

        if((randEnemy == 2) && (Random.Range(0,100) > 99))
            Instantiate(enemy[randEnemy-1], pos, Quaternion.identity);
        else
            Instantiate(enemy[randEnemy] , pos, Quaternion.identity);
        
            
            

        if(counter == 20)
        {
            timer.maxTime = 0.6f;
        }
        if (counter == 40)
        {
            timer.maxTime = 0.45f;
        }
        if (counter == 60)
        {
            timer.maxTime = 0.3f;
        }





    }

}
