using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaterGunShoot : MonoBehaviour
{
    [SerializeField] private InputActionReference shootReference;
    [SerializeField] private AudioSource WaterSound;

    private void Awake()
    {
        shootReference.action.performed += OnShoot;
    }

    void OnShoot(InputAction.CallbackContext obj)
    {
        if (!WaterSound.isPlaying)
        {
            WaterSound.Play();
        }
        if (obj.canceled)
        {
            WaterSound.Stop();
        }
    }
}
