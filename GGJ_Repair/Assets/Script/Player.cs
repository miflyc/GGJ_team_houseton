using System.Collections;
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
    [SerializeField] private Sprite[] cloth; 
    private float myspeed;
    private int HP;
    private int MaxHp;
    //private AudioSource myaudio;
    [SerializeField] private AudioClip[] myaudioClips;
    [HideInInspector]private int point;
    [HideInInspector]public int rank;
    [SerializeField] private float augerforce;
    public AudioSource[] audioSources;
    public float breakforce;
    //private Vector3 currentdirr;
    private Rigidbody2D rg;
    [SerializeField] private float force1;
    [SerializeField] private float force2;
    // Start is called before the first frame update
    void Start()
    {
        myspeed = speed;
        MaxHp = 100;
        HP = 0;
       
        rg = GetComponent<Rigidbody2D>();
        point = 0;
        rank = 1;
       // myaudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(speed);
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

        float translationx = Input.GetAxis(DHirozical);
        //Debug.Log(Input.GetAxis(DHirozical));
        float translationy = Input.GetAxis(Dvertical);
        
        //Debug.Log(Input.GetAxis(Dvertical));
        // if (translationx > currentdirr.x)
        rg.rotation -=translationx*augerforce ;//(Mathf.Lerp(0.0f, anger, Time.deltaTime * augerforce));
        // else
        // rg.MoveRotation(Mathf.Lerp(0.0f, -anger, Time.deltaTime * augerforce));

        // rg.rotation = Mathf.Lerp(anger, 0.0f, augerforce*Time.deltaTime);
        //currentdirr = Vector2.Lerp(currentdirr + vector2, currentdirr, augerforce * Time.deltaTime);//(currentdirr + vector2).normalized;


        if (Input.GetButton(Dacc))
        {
            // speed = myspeed;
            Debug.Log("In");
            //Debug.Log(currentdirr);
            rg.AddForce(transform.up * speed);
            //Debug.Log(rg);
            audioSources[0].clip = myaudioClips[2];
            audioSources[0].Play();
            audioSources[0].clip = myaudioClips[0];
            audioSources[0].loop = true;
            audioSources[0].Play();
            
        }
        else
        {
            Debug.Log("Stop");
            audioSources[0].clip = myaudioClips[1];
            audioSources[0].loop = true;
            audioSources[0].Play();
        }

        if (Input.GetButton(Dbreak))
        {
           // rg.velocity = new Vector2(0.0f, 0.0f);
        }
       
           
        
       // translationx *= Time.deltaTime;
        //translationy *= Time.deltaTime;
       // transform.position = new Vector3(transform.position.x +  translationx,transform.position.y- translationy, transform.position.z);
    }


    void Skill()
    {
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            rg.AddForce((this.transform.position - collision.transform.position)*force1);
        }
        if (collision.gameObject.layer == 9)
        {
            rg.AddForce((this.transform.position - collision.transform.position) * force2);
        }

    }

    public void PlayerGain()
    {
        audioSources[3].loop = false;
        audioSources[3].Play();

    }

    public void DamageGet(int damage)
    {
        HP -= damage;
        if (HP <= 0)
            HP = 0;
        Detect();
    }

    public void PointGet(int ppoint)
    {
        point += ppoint;

    }

    public void Health(int health)
    {
        if (HP + health >= 100)
            HP = 100;
        else
            HP += health;
        Detect();
    }

    private void Detect()
    {
        if (HP > 20)
        {
            if (HP > 40)
            {
                if (HP > 60)
                {
                    if (HP > 80)
                    {
                        GetComponent<SpriteRenderer>().sprite = cloth[4];
                        speed = 50;
                    }
                    else
                    {
                        GetComponent<SpriteRenderer>().sprite = cloth[3];
                        speed =40;
                    }
                }
                else
                {
                    GetComponent<SpriteRenderer>().sprite = cloth[2];
                    speed =30;
                }
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = cloth[1];
                speed =20;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = cloth[0];
            speed =10;
        }
    }
    //  void Playerthe()
    //{
    //      myaudio.loop = false;
    //      myaudio.Play();
    // }

    // void Changethe(int i)
    //{
    //     myaudio.clip = myaudioClips[i];
    // }
}
