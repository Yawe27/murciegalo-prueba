using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosSpawnerPooling : MonoBehaviour
{
    [Header("Objeto Enemigo")]
    public GameObject enemies;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0, 100)  < 3)
        {
            //Creamos enemigo para referenciar el objeto para usarlo

            GameObject enemigo = EnemyPooling.singleton.Get("Enemy");
            //Si encuentra algun enemigo realiza el if
            if(enemigo != null)
            {
                //Creamos los enemigos en una posicion aleatoria
                enemigo.transform.position = this.transform.position + new Vector3(Random.Range(-10, 10), 0, 0);
                //Activamos el enemigo para que se vea
                enemigo.SetActive(true);
            }
        }





    }
}
