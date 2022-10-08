using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    //Serialized
    [SerializeField] internal AudioClip[] audioClips;

    //References (scripts)
    private GunShoot gun;

    //Targets
    [SerializeField] internal GameObject[] Targets;
    internal int TargetCount;

    //misc
    internal bool Won = false, Restart = false;

    private void Awake()
    {
        Targets = GameObject.FindGameObjectsWithTag("Target");
    }
    void Start()
    {
        TargetCount = Targets.Length;
    }
    void TargetManager()
    {
        if (TargetCount > 0) return;
        else if(TargetCount <= 0)
        {
            Won = true;
            Restart = true;
        }
    }
}
