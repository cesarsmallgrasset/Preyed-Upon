using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenKey : MonoBehaviour
{
    private GameManager manager;
    private AudioSource key;

    private void Awake()
    {
        key = GetComponent<AudioSource>();
        manager = GameObject.FindObjectOfType<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
              
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            manager.mKeyCollected = true;
            this.gameObject.SetActive(false);
            key.Play();
        }
    }
}
