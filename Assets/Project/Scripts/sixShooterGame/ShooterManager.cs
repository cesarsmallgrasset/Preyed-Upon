using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    //Serialized
    [SerializeField] internal AudioClip audioClip;

    //References (scripts)
    private GunShoot gun;
    private TargetHit targets;
    //Targets
    [SerializeField] internal GameObject[] Targets;
    internal int TargetCount;

    //misc
    internal bool Won = false, Restart = false;

    private void Awake()
    {
        gun = GameObject.FindObjectOfType<GunShoot>();
        targets = GameObject.FindObjectOfType<TargetHit>();

        Targets = GameObject.FindGameObjectsWithTag("Target");
    }
    void Start()
    {
        TargetCount = Targets.Length;
    }
    private void Update()
    {
        TargetManager();
        if (gun.bulletCount == Targets.Length && targets.Restart) Restart = false; targets.Restart = false;
    }
    void TargetManager()
    {
        for(int i = 0; i < TargetCount; i++)
        if (TargetCount > 0) return;
        else if(TargetCount <= 0)
        {
            Won = true;
            Restart = true;
        }
        else if(TargetCount > 0 && gun.bulletCount == 0 && gun.hit.collider.name != Targets[i].name)
        {
            Restart = true;
        }
    }
}
