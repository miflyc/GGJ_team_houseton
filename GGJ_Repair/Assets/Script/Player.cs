using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [HideInInspector] public KeyCode Dup;
    [HideInInspector] public KeyCode Ddown;
    [HideInInspector] public KeyCode Dleft;
    [HideInInspector] public KeyCode Dright;
    [HideInInspector] public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(Dup)) //up
        {
            Debug.Log("up" + Dup);
            transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);
        }
        if (Input.GetKey(Ddown)) //down
            transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        if (Input.GetKey(Dleft)) //left
            transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        if (Input.GetKey(Dright))
            transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);//right

    }


    void Skill()
    {

    }
}
