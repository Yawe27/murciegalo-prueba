using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyUI : MonoBehaviour
{
    public GameObject rs;

    float counter;
    // Start is called before the first frame update
    void Start()
    {
        rs.SetActive(false);

        Destroy(this.gameObject, 8);
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter == 7)
        {
            rs.SetActive(true);
        }
    }
}
