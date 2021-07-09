using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float speed;

    public Vector3 bulletOffset;
    public float fireRate = 3f;
    public float nextFire = 0f;
    public float numberofShot;
    public GameObject bulletPrefab;
    
    public GameObject levelPanel;
    Rigidbody2D rg2d;
    public bool compiling;
    public bool upgraded;

    public TimerCD timer;

    // Start is called before the first frame update
    void Start()
    {
        upgraded = false;
        rg2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer.Update();

        if (compiling)

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
                touchPos.z = 0;
                if (touch.phase == TouchPhase.Moved)
                {
                    rg2d.MovePosition(new Vector2(touchPos.x, touchPos.y) + new Vector2(0,1));

                    if (Time.time > nextFire)
                    {
                        nextFire = Time.time + fireRate;
                        Instantiate(bulletPrefab, touchPos + bulletOffset, Quaternion.identity);
                    }
                }
            }

            else
            {
                var mousePos = Input.mousePosition;

                var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 1));
                wantedPos.z = 0;
                transform.position = wantedPos;

                if (Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    Instantiate(bulletPrefab, this.transform.position + bulletOffset, Quaternion.identity);
                }
            }




    }


}
