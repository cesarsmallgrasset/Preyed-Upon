using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WGBalloonPop : MonoBehaviour
{
    WaterGunHit wgHit;
    internal AudioSource popSound;
    [SerializeField] AudioClip popClip;

    private void Awake()
    {
        wgHit = GameObject.FindObjectOfType<WaterGunHit>();
    }

    private void Update()
    {
        if(wgHit.nbOfParticles == wgHit.MaxPressure)
        {
          popSound.PlayOneShot(popClip); 
        }

    }
}
