using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_Screams : MonoBehaviour
{
    new AudioSource audio;

    public float time = 3f;
    public float repeat_rate = 15f;
    int value = 0;
    public float probabilitees = 1;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        InvokeRepeating("PlayCheck", time, repeat_rate);
    }

    void PlayCheck()
    {
        value = Random.Range(0, 100);

        if (value >= probabilitees)
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }

        }
    }
}
