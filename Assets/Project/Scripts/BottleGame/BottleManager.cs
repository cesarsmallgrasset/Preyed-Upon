using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleManager : MonoBehaviour
{
   
    [Header("Item")]


    [Tooltip("Adjust to fit the number of bottles currently in the scene")]
    [SerializeField] internal int numberInScene = 1;

    [Tooltip("Insert the name of the GameObject you are using, make sure it is spelled properly and with punctuations")]
    [SerializeField] private string itemName;




    //-----------------------------------------------------------------------------------------------------
    

    private int numberCollected = 0;
    internal bool itemTriggerActivate = false;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name.Contains(itemName) )
        {
            numberCollected++;
            Debug.Log("Collected" + numberCollected);
            BottleCounter();
        }
    }


    void BottleCounter()
    {
        if(numberCollected == numberInScene) 
        {
            itemTriggerActivate = true;
            Debug.Log("You've reached the number of items in the scene");
        }
    }
}
