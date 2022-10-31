using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAudio : MonoBehaviour
{
    private ShooterManager manager;
    [SerializeField]internal AudioSource Victory;
    internal bool play = true;
    private void Awake()
    {
        Victory = GetComponent<AudioSource>();
        manager = GameObject.FindObjectOfType<ShooterManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.won && play) 
        {
            Victory.Play();
            play = false;
        }
    }
}
