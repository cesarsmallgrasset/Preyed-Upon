using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunManager : MonoBehaviour
{
    [SerializeField] internal AudioSource audioSource;
    [SerializeField] private AudioClip victoryClip, defeatClip;
    [SerializeField] internal float MaxPressure = 1000f;
    private WaterGunHit waterGun;
    [SerializeField] private GameObject ticket;
    [SerializeField] new private GameObject audio;
    [SerializeField] private Transform ticketholder;

    internal bool Won = false, lose = false, victory = false, defeat = false;

    private void Update()
    {
        if (Won)
        {
            victory = true;
            //makes a check to see if it can play the sound then disables that check to prevent loop
            if (victory)
            {
                victory = false;
                audioSource.clip = victoryClip;
                audioSource.Play();
               // if (!audioSource.isPlaying) audioSource.gameObject.SetActive(false);
            }
        }
        else if (lose)
        {
            defeat = true;
            if (defeat)
            {
                defeat = false;
                audioSource.clip = defeatClip;
                audioSource.Play();
               // if (!audioSource.isPlaying) audioSource.gameObject.SetActive(false);
            }
        }
    }

}
