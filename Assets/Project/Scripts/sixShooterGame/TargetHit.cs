using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Animator))]
public class TargetHit : MonoBehaviour
{
    private GunShoot gun;
    private ShooterManager manager;

    private MeshCollider targetCol;
    private Animator animator;
    private new AudioSource audio;

    internal bool Restart = false, shot = false;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        gun = GameObject.FindObjectOfType<GunShoot>();
        manager = GameObject.FindObjectOfType<ShooterManager>();
        targetCol = GetComponentInChildren(typeof(MeshCollider)) as MeshCollider;
        audio.clip = manager.audioClip;
    }

    private void Update()
    {
        hitCheck();
    }

    private void hitCheck()
    {

        if (gun.hit.collider == targetCol)
        {
            shot = true;
            if (shot)
            {
                //Animation for when collision happens
                animator.SetBool("isHit", true);

                //Sound that comes from impact
               // audio.Play();

                //Decreases total target count
                manager.TargetCount--;
                Debug.Log(this.gameObject.name);
                shot = false;
            }
        }
    }
    void restart()
    {
        if (manager.Restart)
        {
            animator.SetBool("Reset", true);
            Restart = true;
        }
    }
}
