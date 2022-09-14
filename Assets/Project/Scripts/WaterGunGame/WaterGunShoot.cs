using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaterGunShoot : MonoBehaviour
{
    [SerializeField] private InputActionReference shootReference;
    [SerializeField] private Transform barrel;
    [SerializeField] private float shootDistance = 5f;
    private RaycastHit hit;

    private bool canShoot;

    private void Awake()
    {
        shootReference.action.performed += OnShoot;
    }

    void OnShoot (InputAction.CallbackContext obj)
    {
        Physics.Raycast(barrel.position, barrel.forward, out hit, shootDistance);

        Debug.Log("Raycast distance: " + hit);

    }
}
