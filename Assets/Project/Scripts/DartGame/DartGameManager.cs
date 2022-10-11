using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DartGameManager : MonoBehaviour
{

    //[SerializeField] List<GameObject> Darts = new List<GameObject>();
    //[SerializeField] List<GameObject> Balloons = new List<GameObject>();
    //[SerializeField] internal int nbBalloons, nbDarts;
    //[SerializeField] Balloon balloon;
    //[SerializeField] private Transform dartRespawn;
    //[SerializeField] private GameObject DartReference;
    //internal int balloonsRemaining, dartsRemaining;
    //internal bool Victory = false, setActive = false, Won = false, dartThrown = false;
    //private void Awake()
    //{
    //    balloonsRemaining = nbBalloons;
    //    dartsRemaining = nbDarts;


    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.name.Contains(DartReference.name))
    //    {
    //        dartThrown = true;

    //    }
    //}
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.name.Contains(DartReference.name))
    //    {
    //        if (dartThrown == true)
    //        {
    //            dartsRemaining--;
    //            Debug.Log("Lost a dart, darts remaining: " + dartsRemaining);
    //            Debug.Log("Balloons remaining: " + balloonsRemaining);
    //            dartThrown = false;

    //        }
    //    }
    //}



    //private void Update()
    //{
    //    if(balloonsRemaining  == 0)
    //    {
    //        Victory = true;
    //        Won = true; 
    //    }
    //    if (balloonsRemaining > 0 && dartsRemaining <= 0)
    //    {
    //        //restart
    //        balloonsRemaining = nbBalloons;
    //        for (int i = 0; i < nbBalloons; i++)
    //        {
    //            Balloons[i].SetActive(true);
    //        }
    //        Debug.Log("Set back to active");
    //        for (int i = 0; i < nbDarts; i++)
    //        {
    //            Debug.Log("Resetting Darts");
    //            dartsRemaining = nbDarts;
    //            Darts[i].transform.position = dartRespawn.position;
    //        }
    //    }

    //}GameObject[]



    GameObject[] balloons, darts;
    [SerializeField] internal AudioClip popSound, victory, lose;
    new Animation animation;
    Balloon balloon;
    internal bool Won = false, restart = false, entered = false;
    internal int dartsLeft, balloonsLeft;

    internal Vector3[] respawnLoc;
    internal Quaternion[] respawnPos;
    private void Awake()
    {

        balloon = GameObject.FindObjectOfType<Balloon>();
        balloons = GameObject.FindGameObjectsWithTag("Balloon");
        darts = GameObject.FindGameObjectsWithTag("Dart");

    }
    private void Start()
    {
        balloonsLeft = balloons.Length;
        dartsLeft = darts.Length;
        for (int i = 0; i < darts.Length; i++)
        {
            respawnLoc[i] = darts[i].transform.position;
            respawnPos[i] = darts[i].transform.rotation;
        }
    }
    private void Update()
    {
        VictoryCheck();
        Debug.Log(balloonsLeft);
        Debug.Log(dartsLeft);

    }
    private void OnTriggerEnter(Collider other)
    {
        for(int i = 0; i < darts.Length; i++)
        if(other.gameObject == darts[i].gameObject)
            {
                entered = true;
                Debug.Log("entered");
            }
    }
    private void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < darts.Length; i++)
            if (other.gameObject == darts[i].gameObject && entered)
            {
                dartsLeft--;
                entered = false;
                Debug.Log("Exited");

            }
    }
    void VictoryCheck()
    {
        if(balloonsLeft <= 0)
        {
            Won = true;
            Debug.Log("Won");
        }
        else if (balloonsLeft > 0 && dartsLeft <= 0)
        {
            restart = true;
            if (restart)
            {
                Restart();
            }
        }
    }
    void Restart()
    {
        for (int i = 0; i < darts.Length; i++)
        {

            darts[i].transform.position = respawnLoc[i];
            darts[i].transform.rotation = respawnPos[i];
        }
        for (int i = 0; i < balloons.Length; i++) {
            balloons[i].SetActive(true);
        }
        balloonsLeft = balloons.Length;
        dartsLeft = darts.Length;
        restart = false;

    }
}
