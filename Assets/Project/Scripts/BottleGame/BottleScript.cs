using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BottleScript : MonoBehaviour
{
    [SerializeField] GameObject item;

    internal bool complete = false;

    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "SM_Prop_Crate")
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
