﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [HideInInspector] public string Dvertical;
    [HideInInspector] public string DHirozical;
    [HideInInspector] public string Dacc;
    [HideInInspector] public string Dbreak;
    [HideInInspector] public float speed;
    private Audio myaudio;
    [HideInInspector]public int point;
    [HideInInspector]public int rank;
    
    // Start is called before the first frame update
    void Start()
    {
        point = 0;
        rank = 1;
        myaudio = GetComponent<Audio>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //  if (Input.GetKey(Dup)) //up
       //  { 
       //       Debug.Log("up" + Dup);
       //       transform.position = new Vector3(transform.position.x, transform.position.y + speed*Time.deltaTime, transform.position.z);
        //  }
        //  if (Input.GetKey(Ddown)) //down
        //     transform.position = new Vector3(transform.position.x, transform.position.y - speed*Time.deltaTime, transform.position.z);
         //  if (Input.GetKey(Dleft)) //left
         //     transform.position = new Vector3(transform.position.x - speed*Time.deltaTime, transform.position.y, transform.position.z);
         // if (Input.GetKey(Dright))
        //      transform.position = new Vector3(transform.position.x + speed*Time.deltaTime, transform.position.y, transform.position.z);//right
       // Skill();
        float translationx = Input.GetAxis(DHirozical) * speed;
        Debug.Log(Input.GetAxis(DHirozical));
        float translationy = Input.GetAxis(Dvertical) * speed;
        Debug.Log(Input.GetAxis(Dvertical));
        translationx *= Time.deltaTime;
        translationy *= Time.deltaTime;
        transform.position = new Vector3(transform.position.x +  translationx,transform.position.y- translationy, transform.position.z);
    }


    void Skill()
    {
        if (Input.GetKey(KeyCode.V))
        {
            Debug.Log("v");
            myaudio.isloop = true;
        }
        if (Input.GetKeyUp(KeyCode.V))
        {
            Debug.Log("Dv");
            myaudio.isloop = false;
        }
    }
}
