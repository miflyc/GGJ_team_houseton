using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int currentlevel;
    // Start is called before the first frame update
    void Start()
    {
        currentlevel = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Loadthenext()
    {
        DontDestroyOnLoad(this);
        if (SceneManager.sceneCountInBuildSettings -1> currentlevel)
        {  //SceneManager.LoadScene(currentlevel + 1);
            SceneManager.LoadScene(currentlevel + 1);
            //Debug.Log(SceneManager.sceneCountInBuildSettings);
            currentlevel++;
        }
        else
            Debug.Log("We are done");       
    }  
}
