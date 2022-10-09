using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunManager : MonoBehaviour
{
    [SerializeField] AudioSource victorysound;
    [SerializeField] internal float MaxPressure = 1000f;
    private WaterGunHit waterGun;

    internal bool Won = false;
    private void Awake()
    {
        waterGun = GameObject.FindObjectOfType<WaterGunHit>();
    }
    void Check()
    {
        //debug.log("hit");
        if (waterGun.nbOfParticles == MaxPressure)
        {
            //debug.log("finished!");
            Destroy(waterGun.Balloon);
            if (!victorysound.isPlaying)
            {
                //insert animation
                victorysound.Play();
            }
            Won = true;
        }
    }
}
