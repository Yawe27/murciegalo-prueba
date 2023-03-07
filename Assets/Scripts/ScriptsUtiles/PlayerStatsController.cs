using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatsController : MonoBehaviour
{
    [Header ("Corazones-Vida")]
    public Image[] hearts = new Image[5];

    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int currentHP;
    public int maxHP = 3;

    
    [Header ("Experiencia")]
    public Image xpbar;
    public Text leveltext;
    public int level;
    public float xp;
    public float xpRequired;
    float xpsobrante;

    [Header ("Daño")]
    public float baseDamage = 3;
    public float currentDamage;
    public Vector3 offset;

    public GameObject levelPanel;

    [Header("PowerUPs")] 

    public GameObject damageText; 
    public GameObject cdText; 
    public GameObject hpText; 

    [Range(0, 1)]
    public float percent;

    
    PlayerMov playercd;
    Animator anim;

    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playercd = GetComponent<PlayerMov>();

        
        currentHP = maxHP;
        

        level = 1;

        xp = 0;

        
        

        currentDamage = baseDamage;


    }

    // Update is called once per frame
    void Update()
    {
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }

        leveltext.text = "" + level; 
        xpRequired = 100 * level * Mathf.Pow(level, 0.1f);
        xpbar.fillAmount = xp / (int)xpRequired;
        HP();
        Exp();

        if(currentHP <= 0)
        {
            PlayerPrefs.SetInt("kill", LevelChanges.Instance.Kills);
            SceneManager.LoadScene("RankingMenu");

            Destroy(this.gameObject);

            //FIN DE JUEGO

        }
    }

    public void LevelUp()
    {
        if(xp > xpRequired)
        {
            xpsobrante = xp - xpRequired;
            xpsobrante += xp;
        }  
        

        //Time.timeScale = 0;
        //xp = 0;
        level++;
        //levelPanel.SetActive(true);
        //xpRequired += 50;

    }

    public void Exp()
    {
        if (xp >= xpRequired)
            
            LevelUp();

    }

    public void HP()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHP)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < maxHP)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Cubo"))
    //    {
    //        currentHP++;
    //        Destroy(collision.gameObject);
    //    }
    //}
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cubo"))
        {
            currentHP++;
            Destroy(collision.gameObject);
        }
    }
    #region RandomRoullette
    //public void DamageUp()
    //{
    //    currentDamage += 2;
    //    levelPanel.SetActive(false);

    //    Instantiate(damageText, this.transform.position, Quaternion.identity);
    //    Time.timeScale = 1;
    //}

    //public void CDDown()
    //{

    //    playercd.fireRate -= 0.05f;
    //    levelPanel.SetActive(false);
    //    Instantiate(cdText, this.transform.position, Quaternion.identity);
    //    Time.timeScale = 1;
    //}

    //public void HPUp()
    //{
    //    currentHP += 50;
    //    levelPanel.SetActive(false);
    //    Instantiate(hpText, this.transform.position, Quaternion.identity);
    //    Time.timeScale = 1;
    //}

    //public void randomRoulette()
    //{

    //    int upgrade = Random.Range(1,3);//Aqui sale aleatoriamente un numero entre 1 y 3 

    //    if ((upgrade == 1))
    //    {
    //        DamageUp();
    //    }
    //    if ((upgrade == 2))
    //    {
    //        CDDown();
    //    }
    //    if ((upgrade == 3))
    //    {
    //        HPUp();
    //    }
    //}
    //if(upgrade == 1)//Si ha salido el 1
    //{
    //    int opcion1 = Random.Range(0, 100);//Genera un numero random que realiza la probabilidad(comparacion) para que salga en ese upgrade

    //    if (opcion1 > 70)
    //    {
    //        DamageUp();
    //        Debug.Log("30% aumento de daño");
    //    }
    //}
    #endregion

}





