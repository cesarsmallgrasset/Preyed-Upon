using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleScript : MonoBehaviour
{
    private BottleManager manager;
    private new AudioSource audio;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<BottleManager>();
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != manager.container.name)
        audio.Play();
    }
}
