using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;
    [SerializeField] GunShoot gunshoot;
    internal Animator hitanimator;

    private void Awake()
    {
        hitanimator = GetComponent<Animator>();
        gunshoot = GameObject.FindObjectOfType<GunShoot>();
    }

    private void Update()
    {
        if (gunshoot.hit.collider == this.gameObject)
        {
            hitanimator.SetBool("isHit", true);
            if (!hitSound.isPlaying)
            {

                hitSound.Play();
            }
        }
    }
}
