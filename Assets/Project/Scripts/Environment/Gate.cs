using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private GameManager manager;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float LockedMass, unlockedMass;
    // Start is called before the first frame update
    void Start()
    {
        rb.GetComponent<Rigidbody>();
        rb.mass = LockedMass;
        manager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.canEscape)
        {
            rb.mass = unlockedMass;
        }
    }
}
