using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ShooterGun : MonoBehaviour
{
    [SerializeField] private InputActionReference LeftShoot, RightShoot;
    [SerializeField] private Transform barrel;
    [SerializeField] private float maxDistance = 20f;
    [SerializeField] private int bullets = 6;

    [SerializeField] private AudioSource emptyMag, shootSound;
    [SerializeField] private ShooterManager manager;

    internal RaycastHit hit;
    internal int shotsremaining;
    private bool loaded = true, canReset = true, PickedUp = false;




    private void Awake()
    {
        manager = GameObject.FindObjectOfType<ShooterManager>();
        LeftShoot.action.performed += OnShoot;
        RightShoot.action.performed += OnShoot;
    }
    private void Start()
    {
        shotsremaining = bullets;
    }
    private void Update()
    {

        Debug.DrawRay(barrel.position, (barrel.forward * maxDistance), Color.white);

        //checks if there are bullets in the gun
        if (shotsremaining <= 0) loaded = false;

        //prevents shooting if gun is empty
        if (!loaded)
        {
            Debug.Log("You can no longer shoot"); 
        }
        
        
        //check if needs to reload
        if (manager.reset && !loaded)
        {
            reset();
        }
    }
    void OnShoot(InputAction.CallbackContext obj)
    {

        if (PickedUp)
        {
            if (loaded)
            {//shoots and decrements the shots based on if the gun can shoot or not
                Physics.Raycast(barrel.position, barrel.forward, out hit, maxDistance);
                shotsremaining--;
                shootSound.Play();
                //play audio for shot
            }
            else
            {
                //place the empty gun sound here
                emptyMag.Play();
                loaded = false;
            }
        }
        else return;
    }
    void reset()
    {
        shotsremaining = bullets;
        loaded = true;
        Debug.Log("Reset revolver, " + shotsremaining + "shots remain in gun");
    }

    public void pickedUp()
    {
        PickedUp = true;

    }
    public void dropped()
    {
        PickedUp = false;
    }
}
