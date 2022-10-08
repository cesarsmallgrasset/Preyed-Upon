using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private BottleManager bottleManager;
    [SerializeField]private WaterGunHit watergunManager;
    [SerializeField]private ShooterManager shooterManager;
    [SerializeField] private DartGameManager DartManager;
    [SerializeField] private GameObject Player;
    internal bool canEscape = false;
    private void Awake()
    {

    }

    private void Update()
    {
        if(watergunManager.Won && shooterManager.Won && bottleManager.Won && DartManager.Won)
        {
            canEscape = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            //train code here

        }
    }

}
