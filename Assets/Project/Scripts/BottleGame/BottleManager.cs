using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> Bottles, Balls;
    private List <Transform> BottleRespawn, BallRespawn;

    internal int totalBottles, totalBalls;
    internal bool Won = false;

    private void Awake()
    {
        totalBottles = Bottles.Count;
        totalBalls = Balls.Count;

        for (int i = 0; i < totalBottles; i++)
        {
            BottleRespawn[i].position = Bottles[i].transform.position;
        }
        for (int i = 0; i < totalBalls; i++)
        {
            BallRespawn[i].position = Balls[i].transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(Bottles[0].name))
        {
            totalBottles--;
        }
    }
    private void OnTriggerExit(Collider _other)
    {
        if (_other.gameObject.name.Contains(Balls[0].name))
        {
            totalBalls--;
        }
    }
    private void Update()
    {
        Victory();
    }

    void Victory()
    {
        if(totalBottles <= 0)
        {
            Won = true;
        }
        if(totalBalls <= 0)
        {
            Restart();
        }

    }

    void Restart()
    {
        for(int i = 0; i < Bottles.Count; i++)
        {
            Bottles[i].transform.position = BottleRespawn[i].position;

        }
        for (int i = 0; i < Balls.Count; i++)
        {
            Balls[i].transform.position = BallRespawn[i].position;
        }

    }
}
