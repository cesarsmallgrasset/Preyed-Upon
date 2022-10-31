using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DGBalloon : MonoBehaviour
{
    private DartManager manager;
    [SerializeField] private new DGAudio audio;
    [SerializeField] private AudioSource audioSource;

    private void Awake()
    {
        audio = GameObject.FindObjectOfType<DGAudio>();
        manager = GameObject.FindObjectOfType<DartManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Dart")
        {
            audio.source.transform.position = this.gameObject.transform.position;
            audio.play = true;
            manager.balloonCount--;
            gameObject.SetActive(false);
        }
    }
}
