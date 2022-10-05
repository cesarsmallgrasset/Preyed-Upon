using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
   
    [Header("Item")]
    [SerializeField] private List<GameObject> Bottles = new List<GameObject>();

    [Tooltip("Insert the name of the GameObject you are using, make sure it is spelled properly and with punctuations")]
    private string bottleName, ballName;
    internal int BottlesLeft = 1, ballsLeft = 1;
    internal Transform BottleLocat;
    [SerializeField] private GameObject BottleGroup;


    [Header ("Balls")]
    [Tooltip("Add all of the throwables into this list here")]
    [SerializeField] private List<GameObject> Balls = new List<GameObject>();
    [Tooltip("Reference to the pack of throwable items")]
    [SerializeField] private GameObject Throwables;
    internal Transform throwLocat;
    private bool ballEntered = false;
    private int numberCollected = 0;
    internal bool Won = false;

    //-----------------------------------------------------------------------------------------------------

    private void Start()
    {
        bottleName = Bottles[0].name;
        ballName = Balls[0].name;
        throwLocat = Throwables.transform;
        BottleLocat = BottleGroup.transform;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains(bottleName) )
        {
            numberCollected++;
            Debug.Log("Collected " + numberCollected);
        }
        if (other.gameObject.name.Contains(ballName))
        {
            ballEntered = true;
        }
    }
    private void OnTriggerExit(Collider _other)
    {

        
        if (_other.gameObject.name.Contains(ballName))
        {
            if (ballEntered)
            {
                ballsLeft--;
                Debug.Log("Number of balls left: " + ballsLeft);
                ballEntered = false;

            }    

        }
    }
    private void Update()
    {
        if (numberCollected == BottlesLeft)
        {
            Won = true;
            Debug.Log("You've reached the number of items in the scene");
        }

        ballsLeft = 0;

        if (ballsLeft == 0)
        { 
            //Destroy all existing items and respawn in new ones
            Destroy(Throwables);
            Destroy(BottleGroup);
            Instantiate(Throwables, throwLocat.position, throwLocat.rotation);
            Instantiate(BottleGroup, BottleLocat.position, BottleLocat.rotation);
        }
    }
}
