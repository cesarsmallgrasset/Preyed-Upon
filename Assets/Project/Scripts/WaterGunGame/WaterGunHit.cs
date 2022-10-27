using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunHit : MonoBehaviour
{
    [Header("References")]

    [Tooltip("Insert the name (or at least a part that is unique) of the particle that will affect this object")]
    [SerializeField] private ParticleSystem particle;
    [Tooltip("Insert the item you want to be blown up")]
    [SerializeField] private GameObject item;
    [Tooltip("Insert the sound you want")]
    [SerializeField] private AudioSource popSound;



    [Header("Variables")]


    [Tooltip("Indicates a number at which the item will pop (delete)")]
    [SerializeField] private float MaxPressure = 1000f;
    [SerializeField] private Vector3 pressureValues;


    private WaterGunManager manager;
    internal float builtPressure = 0;
    internal bool playSound = false;

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<WaterGunManager>();

    }



    private void OnParticleCollision(GameObject other)
    {

        //Set the values to those of the object then increases the size on every call by the amount chosen in inspector
        if (other.name.Contains(particle.name))
        {

            item.transform.localScale += (pressureValues/1000);

            builtPressure++;

            Debug.Log("hit");
            if (builtPressure == MaxPressure)
            {
                balloonPop();
                manager.Won = true;
            }
        }
    }
    void balloonPop()
    {
        popSound.Play();
        item.SetActive(false);

    }
}
