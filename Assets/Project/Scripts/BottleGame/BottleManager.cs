using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    internal bool Entered = false, Won = false, completed = false, Restart = false, isPlaying = true;
    internal int BottlesCollected, BottlesInScene, BallsThrown;
    [SerializeField] internal GameObject[] bottles, balls;
    [SerializeField] internal new AudioSource audio;
    [SerializeField] internal AudioClip victoryClip;
 
    private Vector3[] bottleStartPos, ballStartPos;
    private Quaternion[] bottleStartRot, ballStartRot;

    private void Start()
    {
        bottles = GameObject.FindGameObjectsWithTag("Bottle");
        balls = GameObject.FindGameObjectsWithTag("Baseball");
        BottlesInScene = bottles.Length;
        BallsThrown = balls.Length;


        //bottles value stored
        for (int i = 0; i < bottles.Length; i++)
        {
            bottleStartPos[i] = bottles[i].transform.position;
            bottleStartRot[i] = bottles[i].transform.rotation;
        }
        for(int i = 0; i < balls.Length; i++)
        {
            ballStartPos[i] = balls[i].transform.position;
            ballStartRot[i] = balls[i].transform.rotation;
        }

        
    }
    private void Update()
    {
        restartCheck();
        restart();
    }

    //checks for ball and bottles entering
    private void OnTriggerEnter(Collider other)
    {
        bottleEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        bottleExit(other);
    }

    void restartCheck()
    {
        if (BottlesCollected == BottlesInScene)
        {
            //continue
            Won = true;
            audio.clip = victoryClip;
            bool isPlaying = true;
            audioPlay(isPlaying);

        }
        //  Restart is called
        if (BallsThrown <= 0 && BottlesCollected != BottlesInScene)
        {
            Restart = true;
        }
    }

    private void audioPlay(bool isPlaying)
    {
        if (isPlaying)
        {
            isPlaying = false;
            audio.Play();
        }
    }

    void restart()
    {
        if (Restart)
        {
            Restart = false;

            //bottles value stored
            for (int i = 0; i < bottles.Length; i++)
            {
                bottles[i].transform.position = bottleStartPos[i];
                bottles[i].transform.rotation = bottleStartRot[i];
            }
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].transform.position = ballStartPos[i];
                balls[i].transform.rotation = ballStartRot[i];
            }
        }

    }

    void bottleEnter(Collider other)
    {
        if (other.gameObject.name.Contains(balls[0].name))
        {//ball entered check
            Entered = true;
        }
        if (other.gameObject.name.Contains(bottles[0].name))
        {
            BottlesCollected++;
        }


    } 

    void bottleExit(Collider other)
    {

        if (other.gameObject.name.Contains(balls[0].name) && Entered)
        {
            BallsThrown--;
            Entered = false;

        }
    }

}


