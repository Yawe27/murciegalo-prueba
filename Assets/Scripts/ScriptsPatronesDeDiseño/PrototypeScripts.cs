using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrototypeScripts : MonoBehaviour
{
    //Prototype
    //Este codigo sirve para dar las características necesarias a los cubos que se van a instanciar en la escena
    public static GameObject Clone(Vector3 pos)
    {
        //Creamos el cubo
        GameObject cubitos = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //Añadimos un render para que se vea
        MeshRenderer rend = cubitos.GetComponent<MeshRenderer>();
        rend.material.color = new Color(0, 190, 255);
        //Un rigidbody para que se mueva y pueda colisionar con el collider
        cubitos.AddComponent<Rigidbody>();
        cubitos.GetComponent<Rigidbody>().isKinematic = false;
        
        cubitos.GetComponent<BoxCollider>().isTrigger = true;
        
        cubitos.AddComponent<CubosVidaPrototype>();
        cubitos.name = "Cube(Clone)";



        cubitos.tag = "Cubo";
        cubitos.gameObject.SetActive(true);
        cubitos.transform.position = pos;
        cubitos.transform.localScale = new Vector3(1, 1, 1);
        //cubeClone.AddComponent<TriggerAddLife>();

        return cubitos;
    }
}
