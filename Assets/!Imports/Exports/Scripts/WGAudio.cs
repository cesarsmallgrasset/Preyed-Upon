using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WGAudio : MonoBehaviour
{
    private WGhit manager;
    private bool play = true;
    private AudioSource source;
    private void Awake()
    {
        manager = GameObject.FindObjectOfType<WGhit>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.won)
        {
            if (play)
            {
                source.Play();
                play = false;
            }
        }
    }
}
