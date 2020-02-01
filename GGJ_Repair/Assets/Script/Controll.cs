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
    [Header("how smooth the movement be")]
    public float smooth;
    private GameObject[] findplayers;
    private int[] playerpoint;
    private int[] playerrank;
    public float scale;
    public float maxscale;
    [Header("input the maxcamera position x")]
    public float thecamerax;
    [Header("input the maxcamera position y")]
    public float thecameray;
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
    private GameObject firstplayer;
    private GameObject lastplayer;
    private float distance;
    private Vector3 mainpoint;
    private bool outtheplace;
    private Manager manager;
    [SerializeField]
    [Header("Set the timer of the game(seconds)")]
    private float time;

    // Start is called before the first frame update
    void Awake()
    {
        playerpoint = new int[playersnum];
        manager = GameObject.FindGameObjectWithTag("LevelManagement").GetComponent<Manager>();
        StartCoroutine(timer());
        if (players.Length != 0)
        {
            outtheplace = false;
            if (mycontroller.Length == players.Length)
            {
                playersnum = players.Length;
                playerins.num = playersnum;
                findplayers = new GameObject[playersnum];
                mycamera = this.GetComponent<Camera>();
              //  Debug.Log(mycamera);
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
        {
            Findthefirst();
            CameraFollow();
        }
    }

    void Resbornplayer(int c)
    {
        //Debug.Log(players[c].GetComponent<Player>());
        if (players[c].GetComponent<Player>() != null)
        {
            playerins.up = mycontroller[c].up;
           // Debug.Log("" + playerins.up);
            playerins.down = mycontroller[c].down;
            playerins.left = mycontroller[c].left;
            playerins.right = mycontroller[c].right;
            playerins.PInstantiate(players[c], c, speed);
        }
    }//resborn

    void CameraFollow()
    {

        if (playersnum == 1)
        {
            this.transform.position = new Vector3(findplayers[0].transform.position.x, findplayers[0].transform.position.y, transform.position.z);
           // Debug.Log("I'm following" + FindObjectOfType<Player>().gameObject.transform.position);
        }

        if (playersnum > 1)
        {
            mainpoint = new Vector3((firstplayer.transform.position.x + lastplayer.transform.position.x) / 2, (firstplayer.transform.position.y + lastplayer.transform.position.y) / 2, transform.position.z);
            Isout();
            if (!outtheplace)
            {
                distance = Vector3.Distance(firstplayer.transform.position, lastplayer.transform.position);
                mycamera.orthographicSize = Mathf.Lerp(mycamera.orthographicSize,distance*scale,smooth);
                if (mycamera.orthographicSize >= maxscale)
                    mycamera.orthographicSize = maxscale;
                this.transform.position = Vector3.Lerp(transform.position,mainpoint,Time.deltaTime*smooth);
                // Debug.Log("I'm moving");
            }
            else
               Debug.Log("out");
        }
    }//camera follow;

    void Findthefirst()
    {
        firstplayer = findplayers[0];
        lastplayer = findplayers[1];

    }//wait for the find the first

    void Isout()
    {

        if (thecamerax > Mathf.Abs(transform.position.x) && thecameray > Mathf.Abs(transform.position.y))
        {
           
            outtheplace = false;
        }
        else
        {
            
            outtheplace = true;
        }
    }//detect the bounce

    IEnumerator timer()
    {
        yield return new WaitForSeconds(time);

        Debug.Log("play the UI of result");
        Time.timeScale = 0;

    }//timer system

    void CountthePoint()
    {
        for (int f = 0; f < playersnum; f++)
        {
            playerpoint[f] = findplayers[f].GetComponent<Player>().point;
            playerrank[f] = findplayers[f].GetComponent<Player>().rank;
        }
        
    }

}
