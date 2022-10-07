using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    internal bool Restart = false, Entered = false, Won = false;
    private int BottlesCollected, BottlesInScene, BallsThrown;
    [SerializeField] private GameObject[] bottles, balls;
    
    private void Start()
    {
        bottles = GameObject.FindGameObjectsWithTag("Bottle");
        balls = GameObject.FindGameObjectsWithTag("Baseball");
        BottlesInScene = bottles.Length;
        BallsThrown = balls.Length;
        
    }
    private void Update()
    {
        GameRestart();
        Debug.Log(BallsThrown);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(balls[0].name))
        {
            Entered = true;
        }
        if (other.gameObject.name.Contains(bottles[0].name))
        {
            BottlesCollected++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains(balls[0].name))
        {
            BallsThrown--; 
            Entered = false;
        }
    }
    void GameRestart()
    {
        if (BottlesCollected == BottlesInScene)
        {
            Won = true;
        }
        if (BallsThrown <= 0)
        {
            Debug.Log("Restarting");
            Restart = true;
        }


    }
}
