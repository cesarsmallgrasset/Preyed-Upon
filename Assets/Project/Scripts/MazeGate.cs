using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGate : MonoBehaviour
{
    private GameManager manager;
    private Rigidbody rb;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rb.mass = 1000;
    }


    private void Update()
    {
        if (manager.mKeyCollected)
        {
            rb.mass = 1;
        }
    }
}
