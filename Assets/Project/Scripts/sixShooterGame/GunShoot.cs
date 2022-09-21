using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    [Header("Action Map References")]
    [SerializeField] private InputActionReference ShootReferenceRight;
    [SerializeField] private InputActionReference ShootReferenceLeft;

    [Header("Shoot references")]
    [SerializeField] private Transform Barrel;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private GameObject Cylinder;
    [SerializeField] private ParticleSystem gunSmoke;
    [SerializeField] private Animation recoilAnimation;

    [SerializeField] private int maxDistance;
    RaycastHit hit;

    private void Awake()
    {
        ShootReferenceRight.action.performed += OnShoot;
        ShootReferenceLeft.action.performed += OnShoot;
    }

    void OnShoot(InputAction.CallbackContext obj)
    {
        ShootStart();
        ShootSequence();
    }
    void ShootStart()
    {
        gunSmoke.Play();
        shootSound.Play();
        recoilAnimation.Play();
    }
    void ShootSequence()
    {
        Physics.Raycast(Barrel.position, Barrel.forward, out hit, maxDistance);

        if (hit.collider == null) {Debug.Log("Nothing was hit"); return;}

        else {
            Destroy(hit.collider);
            Debug.Log(hit.collider);}
    }

}
