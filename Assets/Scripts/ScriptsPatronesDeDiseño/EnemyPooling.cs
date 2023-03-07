using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

[System.Serializable]


/// <summary>
/// Este script sirve para tener distintas variables y poder acceder a ellas facilmente
/// </summary>
public class Pool
{
    public GameObject enemyPrefab;

    public int enemiesAmounts;

    public bool moreEnemies;
}
/// <summary>
/// El script EnemyPooling realiza la instancia de cada objeto utilizado, en este caso los enemigos, 
/// ademas de crear en una funcion para crear la lista de objetos requeridos y agregarle la tag devolviendonos el objeto para ser utilizaado
/// </summary>
public class EnemyPooling : MonoBehaviour
{
    public List<GameObject> enemyPool;
    public List<Pool> enemies;

    public static EnemyPooling singleton;

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        enemyPool = new List<GameObject>();

        foreach (Pool enemy in enemies)
        {
            for (int i = 0; i < enemy.enemiesAmounts; i++)
            {
                GameObject obj = Instantiate(enemy.enemyPrefab);

                obj.SetActive(false);

                enemyPool.Add(obj);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject Get(string tag)
    {
        //Hacemos una pasada por la lista de objetos reutilizables
        for (int i = 0; i < enemyPool.Count; i++)
        {
            //Si el objeto concreto no está activo en la jerarquía y además su etiqueta coincide con la pasada por parámetro
            if (!enemyPool[i].activeInHierarchy && enemyPool[i].tag == tag)
            {
                //Devolvemos ese objeto concreto
                return enemyPool[i];
            }
        }

        //Hacemos una pasada por toda la lista de tipos de objetos del pool
        foreach (Pool enemy in enemies)
        {
            //Si la etiqueta del objeto que buscamos coincide con la del tipo de objeto sobre el que queremos trabajar, y es ampliable en el Pool
            if (enemy.enemyPrefab.tag == tag && enemy.moreEnemies)
            {
                //Instaciamos un nuevo objeto de ese tipo
                GameObject obj = Instantiate(enemy.enemyPrefab);
                //Desactivamos ese objeto en concreto con la finalidad de que pueda ser reutilizado
                obj.SetActive(false);
                //Añadimos ese objeto en concreto a la lista de objetos reutilizables
                enemyPool.Add(obj);
                //Nos devuelve este objeto en concreto para ser utilizado
                return obj;
            }
        }

        //De lo contrario nos devuelve una referencia vacía
        return null;
    }
}
