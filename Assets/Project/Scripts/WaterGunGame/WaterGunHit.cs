using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunHit : MonoBehaviour
{
    [Header("References")]

    [Tooltip("Insert the name (or at least a part that is unique) of the particle that will affect this object")]
    [SerializeField] private ParticleSystem Water;
    [Tooltip("Insert the item you want to be blown up")]
    [SerializeField] private GameObject item;
    [Tooltip("Insert the sound you want")]
    [SerializeField] private AudioSource victorySound, balloonPop;
    //[Tooltip("Insert the animation you want")]
    //reference the animation here


    [Header("Variables")]


    [Tooltip("Indicates a number at which the item will pop (delete)")]
    [SerializeField] private float MaxPressure = 1000f;
    [SerializeField] private Vector3 Values;
    internal float nbOfParticles = 0;
    internal bool Won = false;

    private void OnParticleCollision(GameObject other)
    {

        //Set the values to those of the object then increases the size on every call by the amount chosen in inspector
        if (other.name.Contains(Water.name))
        {

            item.transform.localScale += (Values/1000);

            nbOfParticles++;

            Debug.Log("hit");
            if (nbOfParticles == MaxPressure)
            {
                Debug.Log("Finished!");
                Destroy(item);
                if (!victorySound.isPlaying)
                {
                    //insert animation
                    victorySound.Play();
                    this.gameObject.SetActive(false);
                }
                Won = true;
            }

        }
    }
}
