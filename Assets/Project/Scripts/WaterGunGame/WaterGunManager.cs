using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunManager : MonoBehaviour
{
    [SerializeField] internal AudioSource victorysound;
    [SerializeField] internal float MaxPressure = 1000f;
    private WaterGunHit waterGun;
    [SerializeField] private GameObject ticket;
    [SerializeField] new private GameObject audio;
    [SerializeField] private Transform ticketholder;

    internal bool Won = false;
    private void Awake()
    {
        waterGun = GameObject.FindObjectOfType<WaterGunHit>();
    }
    //private void Update()
    //{
    //    Check();
    //}

    //void Check()
    //{
    //    //debug.log("hit");
    //    if (waterGun.nbOfParticles == MaxPressure)
    //    {
    //        //debug.log("finished!");
    //        Destroy(waterGun.Balloon);
    //        victorysound.Play();
    //        Instantiate(ticket, ticketholder);
    //        while (victorysound.isPlaying) return;
    //        victorysound.Stop();
    //        audio.SetActive(true);

    //    }
    //    Won = true;
        
    //}

}
