using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadGame : MonoBehaviour
{
    public Text ValueTxt;

    // Start is called before the first frame update
    private void Start()
    {
        ValueTxt.text= SingletonManagerScript.Instance.Value.ToString();
    }

   

    public void SceneLoader()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SingletonManagerScript.Instance.Value++;
    }
    public void SceneInicio()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void DeathScene()
    {
        SceneManager.LoadScene("Inicio");
    }
}

