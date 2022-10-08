using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Footsteps : MonoBehaviour
{
    [SerializeField] private AudioSource footsteps;
    [SerializeField] private AudioClip[] audioSources;

    [SerializeField] private InputActionReference moveRef;
    void Start()
    {

    }


    void CallAudio()
    {
        Invoke("RandomSoundness", 1);
    }

    void RandomSoundness()
    {
        footsteps.clip = audioSources[Random.Range(0, audioSources.Length)];
        footsteps.Play();
        CallAudio();
    }
    void OnMove(InputValue val)
    {
        CallAudio();
    }
}
