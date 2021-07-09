using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShoot : MonoBehaviour
{

    Rigidbody2D rb2d;

    public GameObject bulletPrefab;

    public Vector3 bulletOffset;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.Mouse0))
        //{
        //    Instantiate(bulletPrefab, transform.position - bulletOffset, Quaternion.identity);
        //}
    }
}
