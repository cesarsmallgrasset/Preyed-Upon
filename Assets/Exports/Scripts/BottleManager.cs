using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    [SerializeField] private Transform transformBottles, transformBalls;
    [SerializeField] private GameObject bottles, balls;
    [SerializeField] private int nbBottles, nbBalls;
    [SerializeField] internal GameObject container;
    private int bottlesLeft, ballsLeft;
    [SerializeField] internal bool won;
    private bool canReset = true;

    private GameObject newBall;
    private void Start()
    {
        spawnAndSet();
    }
    void spawnAndSet()
    {
        Instantiate(balls, transformBalls);
        Instantiate(bottles, transformBottles);
        bottlesLeft = nbBottles;
        ballsLeft = nbBalls;
        Debug.Log("Spawned " +nbBalls + " Balls and " + nbBottles + " Bottles at Bottle Game");
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Bottle")
        {
            bottlesLeft--;

        }
        else if(other.gameObject.tag == "Baseball")
        {
            ballsLeft--;

        }
    }
    private void Update()
    {
        victory();
    }
    void victory()
    {
        if (bottlesLeft == 0)
        {
            won = true;
            Debug.Log("Bottle won");
        }
        else if (ballsLeft <= 0 && bottlesLeft > 0)
        {

            if (canReset)
            {
                Destroy(balls);
                spawnAndSet();
                canReset = false;
            }

        }
    }

}
