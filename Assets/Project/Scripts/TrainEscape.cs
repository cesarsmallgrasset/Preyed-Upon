using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainEscape : MonoBehaviour
{
    private Animator animator;
    private GameManager manager;
    [SerializeField] private GameObject Player;
    private bool Escaping;
    private void Awake()
    {
        manager = GameObject.FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.tag == "Player")
        {
            animator.SetBool("CanEscape", true);
            manager.trainEntered = true;
            other.gameObject.transform.parent = gameObject.transform;
        }
    }
    //private void Update()
    //{
    //    if (Escaping)
    //    {
    //        Player.transform.position = this.gameObject.transform.position;

    //    }
    //}

}
