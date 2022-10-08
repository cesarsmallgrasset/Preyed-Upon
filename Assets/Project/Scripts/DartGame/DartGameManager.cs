using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DartGameManager : MonoBehaviour
{

    [SerializeField] List<GameObject> Darts = new List<GameObject>();
    [SerializeField] List<GameObject> Balloons = new List<GameObject>();
    [SerializeField] internal int nbBalloons, nbDarts;
    [SerializeField] Balloon balloon;
    [SerializeField] private Transform dartRespawn;
    [SerializeField] private GameObject DartReference;
    internal int balloonsRemaining, dartsRemaining;
    internal bool Victory = false, setActive = false, Won = false, dartThrown = false;
    private void Awake()
    {
        balloonsRemaining = nbBalloons;
        dartsRemaining = nbDarts;
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(DartReference.name))
        {
            dartThrown = true;
            
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.name.Contains(DartReference.name))
        {
            if (dartThrown == true)
            {
                dartsRemaining--;
                Debug.Log("Lost a dart, darts remaining: " + dartsRemaining);
                Debug.Log("Balloons remaining: " + balloonsRemaining);
                dartThrown = false;
                
            }
        }
    }



    private void Update()
    {
        if(balloonsRemaining  == 0)
        {
            Victory = true;
            Won = true; 
        }
        if (balloonsRemaining > 0 && dartsRemaining <= 0)
        {
            //restart
            balloonsRemaining = nbBalloons;
            for (int i = 0; i < nbBalloons; i++)
            {
                Balloons[i].SetActive(true);
            }
            Debug.Log("Set back to active");
            for (int i = 0; i < nbDarts; i++)
            {
                Debug.Log("Resetting Darts");
                dartsRemaining = nbDarts;
                Darts[i].transform.position = dartRespawn.position;
            }
        }

    }

}
