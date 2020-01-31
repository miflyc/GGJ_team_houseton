using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerIns : MonoBehaviour
{
    public Transform[] position;
    [HideInInspector]
    public int num;
    [HideInInspector]
    public string up;
    [HideInInspector]
    public string down;
    [HideInInspector]
    public string left;
    [HideInInspector]
    public string right;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PInstantiate(Player playerIn, int b, float speed)
    {

        if (playerIn != null)
        {
            if (num != position.Length)
                Debug.Log("please keep the number the same with players");
            else
            {
                playerIn.Dup = (KeyCode)System.Enum.Parse(typeof(KeyCode), up);
                playerIn.Ddown = (KeyCode)System.Enum.Parse(typeof(KeyCode), down);
                playerIn.Dright = (KeyCode)System.Enum.Parse(typeof(KeyCode), right);
                playerIn.Dleft = (KeyCode)System.Enum.Parse(typeof(KeyCode), left);
                playerIn.speed = speed;
                playerIn.gameObject.tag = "Player" + (b + 1);
                Instantiate(playerIn, position[b]);
            }

        }
    }
}
