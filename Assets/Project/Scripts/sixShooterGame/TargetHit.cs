using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;
    [SerializeField] GunShoot gunshoot;


    private void Awake()
    {
        gunshoot = GameObject.FindObjectOfType<GunShoot>();
    }

    private void Update()
    {
        if (gunshoot.hit.collider == this.gameObject)
        {

            if (!hitSound.isPlaying)
            {

                hitSound.Play();
            }
        }
    }
}
