using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private GameManager manager;
    private HingeJoint hinges;
    private Rigidbody rb;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        hinges = GetComponent<HingeJoint>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rb.mass = 1000;
    }


    private void Update()
    {
        if (manager.houseUnlocked)
        {
            rb.mass = 1;
        }
    }
}
