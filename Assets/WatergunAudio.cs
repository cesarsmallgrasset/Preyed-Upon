using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatergunAudio : MonoBehaviour
{
    public AudioSource audioSource;
    private void Awake()
    {    
    audioSource.loop = false;
    audioSource.playOnAwake = true;
    }
}
