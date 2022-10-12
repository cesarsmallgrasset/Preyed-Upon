using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class Falling_Gondola : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    private new AudioSource audio;
    [SerializeField] private AudioClip clip;
    [SerializeField] private Joint joint; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.clip = clip;
        joint = GetComponent<FixedJoint>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            animator.SetBool("IsFalling", true);
            animator.SetBool("Is_Playing", false);
            rb.useGravity = true;
            Destroy(joint);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
    }
}
