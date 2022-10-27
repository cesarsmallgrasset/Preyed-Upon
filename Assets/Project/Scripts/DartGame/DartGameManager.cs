using UnityEngine;




public class DartGameManager : MonoBehaviour
{
    //for this script
    private GameObject[] darts, balloons;
    private Vector3[] dartPos;
    private Quaternion[] dartRot;

    //for other scripts to access
    [SerializeField] internal AudioSource balloonSource, managerSource;
    internal bool Won, Lost, playSound, managerSound, entered;
    internal int totalBalloons, totalDarts;

    private void Awake()
    {
        darts = GameObject.FindGameObjectsWithTag("Dart");
        balloons = GameObject.FindGameObjectsWithTag("Balloon");
    }

    private void Start()
    {
        totalBalloons = balloons.Length;
        totalDarts = darts.Length;

        for (int i = 0; i < darts.Length; i++) 
        {
            dartPos[i] = darts[i].transform.position;
            dartRot[i] = darts[i].transform.rotation;
        }
    }

    private void Update()
    {
        soundCheck();
        gameCheck();
    }

    //to be verified
    void soundCheck()
    {
        if (playSound)
        {
            playSound = false;
            balloonSource.Play(); 
        }

        if (managerSound)
        {
            managerSound = false;
            managerSource.Play();
        }


    }


    void gameCheck()
    {
        if (totalBalloons <= 0)
        {
            managerSound = true;
            Won = true;
        }

        else if (totalBalloons > 0 && totalDarts <= 0)
        {
            //signal the balloon script to re-enable the balloons
            Lost = true;

            //reset the darts position
            for (int i = 0; i < darts.Length; i++)
            {
                darts[i].transform.position = dartPos[i];
                darts[i].transform.rotation = dartRot[i];
            }

            //Reset the counters for darts and balloons
            totalBalloons = balloons.Length;
            totalDarts = darts.Length;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Dart")
        {
            entered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Dart")
        {
            entered = false;
            totalDarts--;
        }
    }
}
