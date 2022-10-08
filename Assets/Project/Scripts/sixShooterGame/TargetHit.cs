using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class TargetHit : MonoBehaviour
{
    private GunShoot gun;
    private ShooterManager manager;

    private Collider targetCol;
    private Animator animator;
    private AudioSource audio;
    private AudioClip clip;
    private void Awake()
    {
        gun = GameObject.FindObjectOfType<GunShoot>();
        manager = GameObject.FindObjectOfType<ShooterManager>();
        targetCol.GetComponentInChildren<MeshCollider>();

    }

    private void Update()
    {
        hitCheck();
    }
    private void hitCheck()
    {
        if (gun.hit.collider.name == targetCol.name)
        {
            //Animation for when collision happens
            animator.SetBool("isHit", true);

            //Randomizes sound that comes from impact
            clip = manager.audioClips[Random.Range(0, manager.audioClips.Length)];
            audio.PlayOneShot(clip);

            //Decreases total target count
            manager.TargetCount--;
            Debug.Log(this.gameObject.name);
        }
        if (manager.Restart)
        {
            animator.SetBool("Reset", true);
        }
    }
}
