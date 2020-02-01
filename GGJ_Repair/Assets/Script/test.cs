using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private bool isgo;
    // Start is called before the first frame update
    void Start()
    {
        isgo = true;
        StartCoroutine(testclass(5));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("in");
        Debug.Log("out");
    }

    IEnumerator testclass(int x)
    {
        for (int i = 0; i < x; i++)
        {
            do
            {

            }
            while (isgo);
            yield return new WaitForSeconds(2);
            Debug.Log(i);
            
            //Debug.Log("!!!!!!");
        }


    }
}
