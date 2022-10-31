using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    private new ShooterAudio audio;
    private ShooterGun gun;
    [SerializeField] private GameObject[] targets;
    [SerializeField] internal bool won, reset;
    [SerializeField] internal int targetCount;
    private bool hitTarget = false;
    private void Awake()
    {
        audio = GameObject.FindObjectOfType<ShooterAudio>();
        gun = GameObject.FindObjectOfType<ShooterGun>();
        targets = GameObject.FindGameObjectsWithTag("Target");
    }
    private void Start()
    {
        targetCount = targets.Length;
    }
    private void Update()
    {
        victoryCheck();
    }
    void victoryCheck()
    {
        //checking to see if a target was hit
        if (gun.hit.collider != null)
        {
            if (gun.hit.collider.name.Contains(targets[0].name)) hitTarget = true;
            else hitTarget = false;
        }
        //checking if the victory is valid
        if(targetCount <= 0)
        {
            won = true;
        }
        else if(targetCount > 0 && gun.shotsremaining <= 0 && !hitTarget)
        {
            reset = true;
            targetCount = targets.Length;
        }
    }


}
