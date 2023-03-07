using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCubosPrototype : MonoBehaviour
{
    [Header ("Cooldown de Respawn")]
    public float timeRespawnLife;

    private float randomX;
    private float randomY;

    //Esta clase accede al Prototype para hacer que funcione en el juego
    private void Start()
    {
        StartCoroutine(RespawnLife());
    }


    IEnumerator RespawnLife()
    {
        //spawneamos el cubo clonandolo con el metodo de Prototype, añadiendole un material y usando esta corrutina, ademas de darle un color y una tag para futura programación.

        randomX = Random.Range(-10, 10);
        randomY = -34f;
        GameObject cubeLife = PrototypeScripts.Clone(new Vector3(randomX, randomY, 0));
        MeshRenderer rend = cubeLife.GetComponent<MeshRenderer>();
        rend.material.color = new Color(0, 150, 200);
        cubeLife.tag = "Cubo";

        cubeLife.transform.SetParent(gameObject.transform);
        //esperamos cieto tiempo para volver a llamar a la corrutina
        yield return new WaitForSeconds(timeRespawnLife);

      

        StartCoroutine(RespawnLife());
    }

}
