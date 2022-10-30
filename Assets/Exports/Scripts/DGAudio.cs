using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGAudio : MonoBehaviour
{
    private DartManager manager;
    [SerializeField] internal AudioSource source, victory;
    internal bool play, victorySound = true;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<DartManager>();
        source = GetComponent<AudioSource>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            source.Play();
            play = false;
        }
        else if (manager.won)
        {
            if (victorySound)
            {
                victory.Play();
                victorySound = false;
            }

        }
    }
}
