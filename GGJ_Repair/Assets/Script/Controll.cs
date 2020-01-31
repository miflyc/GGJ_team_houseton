using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Controll : MonoBehaviour
{
    [Header("Please select the way Camera follow.Yes for follow camera No for no movement camera")]
    [SerializeField] private bool camerafollow;
    [Header("Is it controlled by controller?")]
    [SerializeField] private bool controller;
    [Header("Is it using Rigidbody?")]
    [SerializeField] private bool isrigidbody;
    [Header("Controlling the number of Players and you have to stick witch player(prefab)")]
    public Player[] players;
    [Header("please type in the speed of player (float)")]
    [SerializeField] private float speed;
    public PlayerIns playerins;
    private GameObject[] findplayers;
    private int playersnum;
    [Serializable]
    public class Controllerbuttom
    {
        [Header("up(Keyboard)")]
        public string up;
        [Header("left(Keyboard)")]
        public string left;
        [Header("right(Keyboard)")]
        public string right;
        [Header("down(Keyboard)")]
        public string down;
    }
    [SerializeField]
    private Controllerbuttom[] mycontroller;
    private Camera mycamera;
    private Player firstplayer;
    private Player lastplayer;

    // Start is called before the first frame update
    void Awake()
    {

        if (players.Length != 0)
        {
            if (mycontroller.Length == players.Length)
            {
                playersnum = players.Length;
                playerins.num = playersnum;
                findplayers = new GameObject[playersnum];
                mycamera = this.GetComponent<Camera>();
                for (int i = 0; i < playersnum; i++)
                {
                    Resbornplayer(i);
                }
            }
            else
                Debug.LogError("Please keep the players' number and the controllers' number same");
        }//pass the number of player and resborn players

    }
    private void Start()
    {
        if (playersnum != 0)
        {
            if (playersnum == 1)
            {
                findplayers[0] = GameObject.FindGameObjectWithTag("Player1");
                Debug.Log(findplayers[0]);
            }
            else
                for (int d = 0; d < playersnum; d++)
                {
                    findplayers[d] = GameObject.FindGameObjectWithTag("Player" + (d + 1));
                }
        }//find and store players

    }
    // Update is called once per frame
    void Update()
    {
        if (camerafollow)
            CameraFollow();
    }

    void Resbornplayer(int c)
    {
        //Debug.Log(players[c].GetComponent<Player>());
        if (players[c].GetComponent<Player>() != null)
        {
            playerins.up = mycontroller[c].up;
            Debug.Log("" + playerins.up);
            playerins.down = mycontroller[c].down;
            playerins.left = mycontroller[c].left;
            playerins.right = mycontroller[c].right;
            playerins.PInstantiate(players[c], c, speed);
        }
    }

    void CameraFollow()
    {

        if (playersnum == 1)
        {
            this.transform.position = new Vector3(findplayers[0].transform.position.x, findplayers[0].transform.position.y, transform.position.z);
            Debug.Log("I'm following" + FindObjectOfType<Player>().gameObject.transform.position);
        }

        if (playersnum > 1)
        {






        }
    }

}
