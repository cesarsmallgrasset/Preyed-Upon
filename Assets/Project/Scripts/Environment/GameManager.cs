using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]private BottleManager bottleManager;
    [SerializeField]private WaterGunHit watergunManager;
    [SerializeField]private GunShoot gunshoot;
    [SerializeField] private DartGameManager DartManager;
    [SerializeField] private GameObject Player;
    internal bool canEscape = false;
    private void Awake()
    {

    }

    private void Update()
    {
        if(watergunManager.Won && gunshoot.Won && bottleManager.Won && DartManager.Won)
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
