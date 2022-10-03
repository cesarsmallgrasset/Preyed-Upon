using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    [Header("Action Map References")]
    [Tooltip("Input maps for controllers go here")]
    [SerializeField] private InputActionReference ShootReferenceRight;
    [SerializeField] private InputActionReference ShootReferenceLeft;
    [SerializeField] List<GameObject> Targets = new List<GameObject>();


    [Header("Shoot references")]
    [Tooltip("Barrel reference for where the ray will shoot out from")]
    [SerializeField] private Transform Barrel;
    [Tooltip("Distance that the ray will shoot out from")]
    [SerializeField] private int maxDistance;
    [Tooltip("Amount of bullets inside of the cylinder of the gun")]
    [SerializeField] internal int BulletCount = 6;
    internal int targetsLeft;
    internal RaycastHit hit;
    internal bool Won = false;
    internal GameObject target;
    private void Awake()
    {
        targetsLeft = Targets.Count;
        ShootReferenceRight.action.performed += OnShoot;
        ShootReferenceLeft.action.performed += OnShoot;
        Debug.Log(Targets.Count + " " + targetsLeft);
    }

    void OnShoot(InputAction.CallbackContext obj)
    {
        if (BulletCount > 0)
        {
            //Raycast to see if there is a target ahead of us that can be hit and decreasing the amount of bullets in gun
            Physics.Raycast(Barrel.position, Barrel.forward, out hit, maxDistance);
            CollisionCheck();
            Victory();
            BulletCount--;

        }
        else
        {
            Debug.Log("Out of bullets");
        }
    }
    void CollisionCheck()
    {
        for (int i = 0; i < Targets.Count; i++)
        {
            if (hit.collider.gameObject == Targets[i])
            {
                target = Targets[i];
                Debug.Log("Hit: " + target);
                Destroy(target);
                targetsLeft--;
                Debug.Log("Left: " + targetsLeft);

            }
        }
    }
    void Victory()
    {
        if (targetsLeft == 0)
        {
            Debug.Log("Victory");
            Won = true;
        }
        if (BulletCount <= 0 && targetsLeft > 0 /* insert a way to see if the collided object was a target*/)
        {
            Debug.Log("Loser");
        }
    }
}
