using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunHit : MonoBehaviour
{
    [Header("References")]

    [Tooltip("Insert the name (or at least a part that is unique) of the particle that will affect this object")]
    [SerializeField] private string particleName;
    [Tooltip("Insert the item you want to be blown up")]
    [SerializeField] private GameObject item;
    [Tooltip("Insert the sound you want")]
    [SerializeField] private AudioSource victorySound, balloonPop;
    //[Tooltip("Insert the animation you want")]
    //reference the animation here


    [Header("Variables")]

    [Tooltip("Insert the value that the item's X axis will inflate by")]
    [SerializeField] private float xValue = 0.0005f;
    [Tooltip("Insert the value that the item's Y axis will inflate by")]
    [SerializeField] private float yValue = 0.001f;
    [Tooltip("Insert the value that the item's Z axis will inflate by")]
    [SerializeField] private float zValue = 0.0005f;
    [Tooltip("Indicates a number at which the item will pop (delete)")]
    [SerializeField] internal float MaxPressure = 1000f;
    
    
    internal float nbOfParticles = 0;
    private float x,y,z;
    private Vector3 itemSize;
    internal bool Won = false;


        private void Start()
    {
        itemSize = item.transform.localScale;
    }

    private void OnParticleCollision(GameObject other)
    {

        //Set the values to those of the object then increases the size on every call by the amount chosen in inspector
        if (other.name.Contains(particleName))
        {
            //values being stored
            itemSize.x += xValue;
            itemSize.y += yValue;
            itemSize.z += zValue;


            item.transform.localScale = itemSize;

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
