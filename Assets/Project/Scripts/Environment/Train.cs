using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    private Animator animator;
    private GameManager manager;
    [SerializeField] internal new Collider collider;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        manager = GameObject.FindObjectOfType<GameManager>();
        collider = GetComponentInChildren<BoxCollider>();




    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (manager.canEscape)
        {
            animator.SetBool("CanEscape", true);
        }
    }

}
