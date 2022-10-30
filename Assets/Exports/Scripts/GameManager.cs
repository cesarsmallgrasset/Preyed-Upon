using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private BottleManager bottle;
    private DartManager dart;
    private WGhit water;
    private ShooterManager shooter;

    [SerializeField] internal bool spawnKey;


    //key stuff for HH
    [SerializeField] private GameObject HHkey;
    [SerializeField] private Transform HHkeySpawnLoc;

    //house key variables
    internal bool hKeyCollected, keySpawned, houseUnlocked;
    
    //maze variables
    internal bool mKeyCollected, gateOpen;

    //train variables
    internal bool trainEntered;
    // Start is called before the first frame update
    void Start()
    {
        bottle = GameObject.FindObjectOfType<BottleManager>();
        dart = GameObject.FindObjectOfType<DartManager>();
        water = GameObject.FindObjectOfType<WGhit>();
        shooter = GameObject.FindObjectOfType<ShooterManager>();
    }

    // Update is called once per frame
    void Update()
    {
        victoryCheck();
        HHpickup();
        mazePickup();
        train();
    }

    void victoryCheck()
    {
        if (bottle.won && dart.won && water.won && shooter.won)
        {
            
            keySpawn();
        }
    }

    void keySpawn()
    {
        if (!keySpawned)
        { 
            Instantiate(HHkey, HHkeySpawnLoc);
            keySpawned = true;
        }
    }

    void HHpickup()
    {
        if (hKeyCollected)
        {
            houseUnlocked = true;
        }
    }
    void mazePickup()
    {
        if (mKeyCollected)
        {
            gateOpen = true;
        }
    }
    void train()
    {
        if (trainEntered)
        {
            Invoke("mainMenu", 10f);
        }

    }
    void mainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
