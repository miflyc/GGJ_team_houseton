using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    private Button mybutton;
    public Manager manager;
    // Start is called before the first frame update
    void Start()
    {
        mybutton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        manager.Loadthenext();

    }
}
