using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTapAttack : MonoBehaviour
{
    public GameObject beam;
    public Vector3 offset;

    PlayerMov keyinput;

    // Start is called before the first frame update
    void Start()
    {

        keyinput = GetComponent<PlayerMov>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount >= 2)
        { 
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            for (int i = 0; i < Input.touchCount; i++)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    if (Input.GetTouch(i).tapCount >= 2)
                    {
                        Instantiate(beam, this.transform.position + offset, Quaternion.identity);

                        Destroy(beam, 6);
                    }
                }
            }
        }
        
        if(keyinput.compiling)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Instantiate(beam, this.transform.position + offset, Quaternion.identity);
            }
        }
        


    }
}
