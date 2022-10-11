using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private BottleManager bottleManager;
    private WaterGunManager watergunManager;
    private ShooterManager shooterManager;
    private DartGameManager dartManager;
    private GameObject Player;
    internal GameObject menu;

    [SerializeField] private InputActionReference menuButton;
    [SerializeField] internal bool canEscape = false;


    private bool opened = false;
    private void Awake()
    {
        bottleManager = GameObject.FindObjectOfType<BottleManager>();
        watergunManager = GameObject.FindObjectOfType<WaterGunManager>();
        shooterManager = GameObject.FindObjectOfType<ShooterManager>();
        dartManager = GameObject.FindObjectOfType<DartGameManager>();
        menu = GameObject.Find("WristMenu");
        Player = GameObject.Find("XR Origin");
        menuButton.action.performed += OnMenu;

    }

    private void Update()
    {
        if(watergunManager.Won && shooterManager.Won && bottleManager.Won && dartManager.Won)
        {
            canEscape = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            //train code here

        }
    }
    void OnMenu(InputAction.CallbackContext obj)
    {
        if (!opened)
        {
            menu.SetActive(true);
            opened = true;
        }
        else if (opened)
        {
            menu.SetActive(false);
            opened = false;
        }
    }
}
