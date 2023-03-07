using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManagerScript : MonoBehaviour
{
    public static SingletonManagerScript Instance {get; private set; }

    public int Value;
    // Start is called before the first frame update
    private void Awake() 
    {
        if(Instance == null)
        {
            Instance=  this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }
    
        
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
