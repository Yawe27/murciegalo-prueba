using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelChanges : MonoBehaviour
{
    public RandomSpawner rs;
    public GameObject RandomSpawner;
    public GameObject Boss;
    public GameObject CanvasLevel;

    public int Kills;

    BosController bosDead;
    PlayerStatsController hpPlayer;

    private static LevelChanges _instance;

    public static LevelChanges Instance
    {
        get { return _instance; }

    }

    void Awake()
    {

        if (_instance == null)
        {

            _instance = this;
            // DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
        //if (rs)
            //rs = GameObject.FindGameObjectWithTag("EnemiesSpawn").GetComponent<RandomSpawner>();
       
            //bosDead = GameObject.FindGameObjectWithTag("Boss").GetComponent<BosController>();
        hpPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsController>();
        muertePlayer();
    }

    // Update is called once per frame
    void Update()
    {

        if (rs.counter >= 1000)
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            RandomSpawner.SetActive(false);
            Boss.SetActive(true);
        }
        //if (Boss)
        //    if (Boss.activeSelf == false)
        //            Boss.SetActive(true);
        //}else if (!Boss)
        //{
        //    RandomSpawner.SetActive(true);
        //}

        

        //if (!bosDead)
        //{   
        //    RandomSpawner.SetActive(true);
        //}
        
        if(CanvasLevel.activeSelf == true)
        {
            RandomSpawner.SetActive(false);
        }

    }
    
    public void muertePlayer()
    {
        if (hpPlayer.currentHP <= 0)
        {
            RandomSpawner.SetActive(false);

            SceneManager.LoadScene("DeathScene");



        }
    }
}
