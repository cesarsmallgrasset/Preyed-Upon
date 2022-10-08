using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crows : MonoBehaviour
{
    AudioSource audio;

    int value  = 3;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("PlayCheck", 5f, 20f);
        
    }
    void PlayCheck()
    {
        value = Random.Range(0, 100);

        //Debug.Log(value);
        if (value >= 1) return;
            if (!audio.isPlaying)
            {
                audio.Play();
            }
    }

}
