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
    public string hirozical;
    [HideInInspector]
    public string vertical;
    [HideInInspector]
    public string acc;
    [HideInInspector]
    public string mbreak;
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
                playerIn.DHirozical = hirozical;
                playerIn.Dvertical = vertical;
                playerIn.Dacc = acc;
                playerIn.Dbreak = mbreak;
                playerIn.speed = speed;
                playerIn.gameObject.tag = "Player" + (b + 1);
                Instantiate(playerIn, position[b]);
            }

        }
    }
}
