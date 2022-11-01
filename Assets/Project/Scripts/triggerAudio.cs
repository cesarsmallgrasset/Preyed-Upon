using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAudio : MonoBehaviour
{
    private new AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            audio.Play();

            Invoke("Destroy", 5f);
        }
    }
    private void Destroy()
    {
        Destroy(this.gameObject);
    }

}
