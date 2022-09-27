using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartGameManager : MonoBehaviour
{

    [SerializeField] List<GameObject> Darts = new List<GameObject>();
    [SerializeField] internal int nbBalloons, nbDarts;
    [SerializeField] Balloon balloon;
    [SerializeField] private Transform dartRespawn;
    [SerializeField] private GameObject DartReference;
    internal int balloonsRemaining, dartsRemaining;
    internal bool Victory = false, setActive = false, Won = false;

    private void Awake()
    {
        balloonsRemaining = nbBalloons;
        dartsRemaining = nbDarts;
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.name.Contains(DartReference.name))
        {
            dartsRemaining--;
            Debug.Log("Lost a dart, darts remaining: " + dartsRemaining);
            Debug.Log("Balloons remaining: " + balloonsRemaining);

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
            setActive = true;
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
