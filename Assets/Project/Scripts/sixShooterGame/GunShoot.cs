using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private InputActionReference ShootReferenceRight;
    [SerializeField] private InputActionReference ShootReferenceLeft;
    [SerializeField] internal int maxDistance;
    [SerializeField] private GameObject barrel;
    private ShooterManager manager;
    
    //Misc
    internal int bulletCount;
    internal RaycastHit hit;

    //audio
    [SerializeField] private AudioClip shot, empty;
    AudioSource shoot;


    private void Awake()
    {
        manager = GameObject.FindObjectOfType<ShooterManager>();
        shoot = GetComponent<AudioSource>();
        ShootReferenceLeft.action.performed += OnShoot;
        ShootReferenceRight.action.performed += OnShoot;

    }

    private void Start()
    {
        bulletCount = manager.Targets.Length;
    }

    void OnShoot (InputAction.CallbackContext obj)
    {
        if(bulletCount > 0)
        {
            shoot.PlayOneShot(shot);
            Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, maxDistance);
            Debug.DrawRay(barrel.transform.position, (barrel.transform.forward * maxDistance), Color.green);
            Debug.Log(hit.collider.name);
            bulletCount--;
        }
        else
        {
            shoot.PlayOneShot(empty);
        }
        if (manager.Restart)
        {
            Debug.Log("restarting");
            bulletCount = manager.Targets.Length;
        }
    }


}
