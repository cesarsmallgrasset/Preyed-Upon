using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenKey : MonoBehaviour
{
    private GameManager manager;
    private AudioSource key;
    float timer = 2;
    private void Awake()
    {
        key = GetComponent<AudioSource>();
        manager = GameObject.FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {

        if (key.isPlaying)
            despawn(timer);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            manager.mKeyCollected = true;
            key.Play();
            this.gameObject.SetActive(false);
        }
    }

    void despawn(float timer)
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {

        }
    }
}

    