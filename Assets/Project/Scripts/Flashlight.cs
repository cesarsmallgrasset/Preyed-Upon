using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Flashlight : MonoBehaviour
{
    [SerializeField] private InputActionReference toggle;
    [SerializeField] private new GameObject light;
    private new bool enabled; 
        private bool on;

    private void Awake()
    {
        toggle.action.performed += OnToggle;
    }

    public void Enable()
    {
        enabled = true;

    }

    void OnToggle(InputAction.CallbackContext obj)
    {
        if (enabled)
        {
            if (!on)
            {
                light.SetActive(true);
                on = true;
            }
            else
            {
                light.SetActive(false);
                on = false;
            }
        }

    }

}
