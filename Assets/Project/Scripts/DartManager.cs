using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartManager : MonoBehaviour
{
    [Tooltip("Set the location transform of where you want the darts to spawn")]
    //this is the location in the editor at which the darts are currently
    [SerializeField] private Transform dartLoc;
    //this goes with the prefab in the project panel
    [Tooltip("Set the dart pack prefab to spawn in")]
    [SerializeField] private GameObject dartPack;
    //this is the variable for the amount of items in this game for counter control
    [Tooltip("Set the amount of the item indicated that is going to be in the scene (based on prefab)")]
    [SerializeField] private int balloonCounter, dartCounter;
    
    private GameObject[] balloons;
    private bool entered;
    [SerializeField] internal bool restart, won;
    internal int balloonCount, dartCount;

    private void Awake()
    {
        balloons = GameObject.FindGameObjectsWithTag("Balloon");
    }

    //inital spawn of darts and setting of number of items
    private void Start()
    {
        spawnAndSet();
    }
    //validates the entry of a dart
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dart") entered = true;
    }
    private void OnTriggerExit(Collider other)
    {
        //checks if a dart had entered the collider then decreases the counter if true
        if (other.gameObject.tag == "Dart" && entered)
        {
            entered = false;
            dartCount--;
        }
    }
    private void Update()
    {
        victory();

    }

    //checks to see if the game was won or not
    void victory()
    {
        //victory
        if (balloonCount == 0)
        {
            won = true;
            Debug.Log("Darts Won");
        }
        //defeat
        else if (balloonCount > 0 && dartCount <= 0)
        {
            //little loop to only do the sequence once and not loop
            int i = 1;
            do
            {
                restart = true;
                spawnAndSet();
                continue;
            } while (i == 0);
        }

    }


    //spawns in new darts and resets the counters for them all
    void spawnAndSet()
    {
        for (int i = 0; i < balloons.Length; i++)
        {
            balloons[i].SetActive(true);
        }
        Instantiate(dartPack, dartLoc);
        balloonCount = balloonCounter;
        dartCount = dartCounter;
        Debug.Log("Spawned " + dartCount + " Darts and " +  balloonCount + " Balloons at Dart Game");
    }

}
