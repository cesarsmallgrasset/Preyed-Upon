using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WGBalloonPop : MonoBehaviour
{
    [SerializeField] WaterGunHit wgHit;
    [SerializeField] AudioSource popSound;

    private void Awake()
    {
        wgHit = GameObject.FindObjectOfType<WaterGunHit>();
    }

    private void Update()
    {
        if(wgHit.nbOfParticles == wgHit.MaxPressure)
        {
            if (!popSound.isPlaying) { popSound.Play(); }
        }

    }
}
