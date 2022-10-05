using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trains : MonoBehaviour
{
    [SerializeField] private GameManager gamemanager;
    [SerializeField] private 

    void Awake()
    {
        gamemanager.GetComponent<GameManager>();

    }


    // Update is called once per frame
    void Update()
    {
        if (gamemanager.canEscape)
        {

            Debug.Log("Can escape");



        }       
    }
}
