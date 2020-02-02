using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private int pointgive;
    [SerializeField] private bool damage;
    [SerializeField] private bool health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            
            if (!damage)
            {
                collision.GetComponent<Player>().PointGet(pointgive);
                collision.GetComponent<Player>().PlayerGain();
            }
            else
            {
                collision.GetComponent<Player>().DamageGet(pointgive);
                
            }

            if (health)
                collision.GetComponent<Player>().Health(pointgive);
            Destroy(this.gameObject);
        }
    }
}
