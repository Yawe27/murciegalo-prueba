using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneValueBTWScenes : MonoBehaviour
{
    public Text ValueTxt;
    
    // Start is called before the first frame update
    void Start()
    {
        ValueTxt.text= SingletonManagerScript.Instance.Value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneLoader()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SingletonManagerScript.Instance.Value++;
    }
}
