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
    internal int targetsLeft, bulletsLeft;
    internal RaycastHit hit;
    internal bool Won = false;
    internal GameObject target;
    private void Awake()
    {
        bulletsLeft = BulletCount;
        targetsLeft = Targets.Count;
        ShootReferenceRight.action.performed += OnShoot;
        ShootReferenceLeft.action.performed += OnShoot;
    }
    private void Update()
    {
        Victory();
    }
    void OnShoot(InputAction.CallbackContext obj)
    {
        if (bulletsLeft > 0)
        {
            //Raycast to see if there is a target ahead of us that can be hit and decreasing the amount of bullets in gun
            Physics.Raycast(Barrel.position, Barrel.forward, out hit, maxDistance);
            CollisionCheck();
            bulletsLeft--;
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
                Targets[i].SetActive(false);
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
        for (int i = 0; i < Targets.Count; i++)
        {
            if (bulletsLeft <= 0 && targetsLeft > 0 && hit.collider.name != Targets[i].name)
            {
                Debug.Log("Loser");
                bulletsLeft = BulletCount;
                targetsLeft = Targets.Count;
                for (int j = 0; j < Targets.Count; j++)
                {
                    Targets[j].SetActive(true);
                }
            }
        }
    }
}
