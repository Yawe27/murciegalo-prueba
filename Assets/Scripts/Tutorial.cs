using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject Spawner;
    float counter;

    // Start is called before the first frame update
    void Start()
    {
        Spawner.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if(counter >= 6)
        {
            Spawner.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
