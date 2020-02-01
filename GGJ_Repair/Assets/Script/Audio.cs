using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    private AudioSource audio1;
    public double startposition;
    private float looptime;
    private int countdown;
    public bool isloop;
    
    // Start is called before the first frame update
    void Start()
    {
        countdown = 0;
        isloop = false;
        audio1 = GetComponent<AudioSource>();
       // audio1.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isloop&& countdown == 0)
        {
            StartCoroutine(forfirsttime());
            countdown = 1;
        }
        if (!isloop)
        {
            StopAllCoroutines();
            audio1.Stop();
            countdown = 0;
        }
    }


    IEnumerator forfirsttime()
    {
        audio1.Play();
        Debug.Log(audio1.clip.length);
        yield return new WaitForSeconds(audio1.clip.length);
        audio1.PlayScheduled(startposition);
        StartCoroutine(forloop());

    }


    IEnumerator forloop()
    {
        do
        {
            yield return new WaitForSeconds(looptime);
            audio1.PlayScheduled(startposition);
            Debug.Log(AudioSettings.dspTime);
        }
        while (isloop);

        
    }
}
